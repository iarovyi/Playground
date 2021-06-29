# Pulumi boilerplate

There are many [pulumi examples](https://github.com/pulumi/examples). Run with:
```powershell
$project="PulumiDev4"
$stack="dev"
$account="XXXXXXXXXX"
$role="Account-Owner"
$region="eu-west-1"
choco install pulumi -y
choco install tf2pulumi -y
saml2aws login --role=arn:aws:iam::$($account):role/saml/$($role) --profile default --force --session-duration 3600 --skip-prompt
pulumi login
pulumi new aws-csharp --yes --name $project --stack $stack
pulumi config set aws:region $region
pulumi config set --secret mySecret myPassword
pulumi stack select $stack
pulumi preview
pulumi up --skip-preview --yes
pulumi stack export
pulumi stack output --json
pulumi destroy --skip-preview --yes
pulumi stack rm dev --force --yes
```