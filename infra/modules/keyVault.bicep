@description('Location')
param location string = resourceGroup().location

@description('Tenant id')
param tenantId string = subscription().tenantId

@description('The name of the Key Vault resource')
param name string

@description('Specifies all secrets {"secretName":"","secretValue":""} wrapped in a secure object.')
@secure()
param secretsObject object

resource keyVault 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: name
  location: location
  properties: {
    sku: {
      name: 'standard'
      family: 'A'
    }
    tenantId: tenantId
    enabledForTemplateDeployment: false
    enableRbacAuthorization: true
    enableSoftDelete: true
    softDeleteRetentionInDays: 90
    networkAcls: {
      defaultAction: 'Allow'
    }
  }
}

resource secrets 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = [for i in range(0, length(secretsObject.secrets)): {
  name: '${name}/${secretsObject.secrets[i].secretName}'
  properties: {
    value: secretsObject.secrets[i].secretValue
  }
  dependsOn: [
    keyVault
  ]
}]

output keyVaultName string = keyVault.name
