# Pedido

## Como baixar o repositório

```powershell
git clone https://github.com/unifeso-poo/pedido
```

## Para quem não conseguir restaurar, fazer o seguinte:

1. Acessar C:\Users\\**SEU USUÁRIO AQUI**\AppData\Roaming\NuGet
2. Substituir conteúdo do Nuget.config por:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
  <packageRestore>
    <add key="enabled" value="True" />
    <add key="automatic" value="True" />
  </packageRestore>
  <bindingRedirects>
    <add key="skip" value="False" />
  </bindingRedirects>
  <packageManagement>
    <add key="format" value="0" />
    <add key="disabled" value="False" />
  </packageManagement>
</configuration>
```

## Para problemas de certificado, conexão não segura, etc. Executar o seguinte comando:
```powershell
dotnet dev-certs https --trust
```

## Para criar os itens necessários para rodar o projeto

## Para rodar em debug
