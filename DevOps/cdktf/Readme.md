# Cloud Development Kit Boilerplate

Deploy using hashicorp cloud development kit:
1. Initialize project
```powershell
# Install prerequisites
choco install terraform --version=0.14.11 --yes
terraform -version
node --version
yarn --version
npm install --global cdktf-cli@next  #npm install @cdktf/provider-aws

# Login
$account="MY AWS ACCOUNT"
$role = "MY AWS ROLE"
saml2aws login --role=arn:aws:iam::$($account):role/saml/$($role) --profile default --force --session-duration 3600 --skip-prompt
#cdktf login - login in case of remote state

# Initialize project
cdktf init --template=csharp --local
```

2. Modify aws provider to `cdktf.json` with
```json
"terraformProviders": [ "aws@~> 3.45" ]
```

3. Deploy
```powershell
cdktf get                          # get dependecies, autogenerate c# classes based on providers and modules
dotnet build                       # build c# project
cdktf synth cdktf                  # autogenerate terraform json configuration
cdktf diff cdktf                   # build a plan of changes
cdktf deploy cdktf --auto-approve  # deploy
cdktf destroy cdktf --auto-approve # destroy
```

4. Experiment in [Main.cs](Main.cs)