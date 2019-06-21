namespace GitHubIntegration
{
    using Octokit;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Reflection;

    public class GitHubRepositoryClient
    {
        private readonly string DefaultHeader = $"{Assembly.GetExecutingAssembly().GetName().Name}-{Assembly.GetExecutingAssembly().GetName().Version}";
        private readonly GitHubClient github;
        private readonly string owner;
        private readonly string reporitoryName;

        public GitHubRepositoryClient(string githubToken, string owner, string reporitoryName, string productHeader = null)
        {
            this.owner = owner;
            this.reporitoryName = reporitoryName;
            github = new GitHubClient(new ProductHeaderValue(productHeader ?? DefaultHeader));
            var tokenAuth = new Credentials(githubToken);
            github.Credentials = tokenAuth;
        }

        public async Task<string> CreateFile(string path, string content, string commitMessage, string branch = "master")
        {
            var changeSet = await github.Repository.Content.CreateFile(
                                            owner,
                                            reporitoryName,
                                            path,
                                            new CreateFileRequest(commitMessage,
                                                                  content,
                                                                  branch));
            return changeSet.Content.Url;
        }

        public async Task<string> UpdateFile(string path, string content, string commitMessage, string branch = "master")
        {
            var existingFile = await github.Repository.Content.GetAllContentsByRef(owner, reporitoryName, path, branch);
            var changeSet = await github.Repository.Content.UpdateFile(
                                            owner,
                                            reporitoryName,
                                            path,
                                            new UpdateFileRequest(commitMessage,
                                                                  content,
                                                                  existingFile.First().Sha,
                                                                  branch));
            return changeSet.Content.Url;
        }

        public async Task<string> UpsertFile(string path, string content, string commitMessage, string branch = "master")
        {
            string existingFileSha = null;
            try
            {
                existingFileSha = (await github.Repository.Content.GetAllContentsByRef(owner, reporitoryName, path, branch)).First().Sha;
            }
            catch (NotFoundException)
            {
                return await CreateFile(path, content, commitMessage, branch);
            }

            var changeSet = await github.Repository.Content.UpdateFile(
                                            owner,
                                            reporitoryName,
                                            path,
                                            new UpdateFileRequest(commitMessage,
                                                                  content,
                                                                  existingFileSha,
                                                                  branch));
            return changeSet.Content.Url;
        }

        public async Task DeleteFile(string path, string commitMessage, string branch = "master")
        {
            var existingFile = await github.Repository.Content.GetAllContentsByRef(owner, reporitoryName, path, branch);
            await github.Repository.Content.DeleteFile(
                                            owner,
                                            reporitoryName,
                                            path,
                                            new DeleteFileRequest(commitMessage,
                                                                  existingFile.First().Sha,
                                                                  branch));
        }

        private async Task<Commit> GetLatestCommit(string branchName)
        {
            var masterReference = await github.Git.Reference.Get(owner, reporitoryName, $"heads/{branchName}");
            return await github.Git.Commit.Get(owner, reporitoryName, masterReference.Object.Sha);
        }


        /* Lowlevel way to upload file
           https://laedit.net/2016/11/12/GitHub-commit-with-Octokit-net.html
           https://octokitnet.readthedocs.io/en/latest/getting-started/
         private async Task UplodFile(string owner, string reporitoryName, string path, string content, string commitMessage, string branchName = "master")
        {
            // 1. Get the SHA of the latest commit of the master branch.
            var headMasterRef = $"heads/{branchName}";
            var masterReference = await github.Git.Reference.Get(owner, reporitoryName, headMasterRef); // Get reference of master branch
            var latestCommit = await github.Git.Commit.Get(owner, reporitoryName, masterReference.Object.Sha); // Get the laster commit of this branch
            var nt = new NewTree { BaseTree = latestCommit.Tree.Sha };

            //2. Create the blob(s) corresponding to your file(s)
            var textBlob = new NewBlob { Encoding = EncodingType.Utf8, Content = content };
            var textBlobRef = await github.Git.Blob.Create(owner, reporitoryName, textBlob);

            // 3. Create a new tree with:
            string blobFileMode = "100644";
            nt.Tree.Add(new NewTreeItem { Path = path, Mode = blobFileMode, Type = TreeType.Blob, Sha = textBlobRef.Sha });
            var newTree = await github.Git.Tree.Create(owner, reporitoryName, nt);

            // 4. Create the commit with the SHAs of the tree and the reference of master branch
            // Create Commit
            var newCommit = new NewCommit(commitMessage, newTree.Sha, masterReference.Object.Sha);
            var commit = await github.Git.Commit.Create(owner, reporitoryName, newCommit);

            // 5. Update the reference of master branch with the SHA of the commit
            // Update HEAD with the commit
            await github.Git.Reference.Update(owner, reporitoryName, headMasterRef, new ReferenceUpdate(commit.Sha));
        }*/
    }
}
