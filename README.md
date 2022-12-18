# Rodando via Docker

Para executar o projeto via docker basta executar os seguintes comandos na pasta raíz

```bash
docker-compose build

docker-compose up
```

Caso rode o comando no Linux é necessário alterar a configuração InterestRateAPIUrl do arquivo appsettings.json no projeto API.Granito.InterestCalculator da seguinte forma:

```json
"APISettings": {
    "InterestRateAPIUrl": "http://172.17.0.1:4001/"
  }
```

## Rodando via IIS Express

Para executar o projeto via IIS Express é necessário ir nas propriedades da solution, marcar a opção "Multiple startup projects" e selecionar "Start" para os projetos API.Granito.InterestCalculator e API.Granito.InterestRate.

![exemplo](https://i.imgur.com/deE0Flb.png)

É preciso alterar a configuração InterestRateAPIUrl do arquivo appsettings.json no projeto API.Granito.InterestCalculator da seguinte forma:

```json
"APISettings": {
    "InterestRateAPIUrl": "https://localhost:44374/"
  }
```

## URLs

O projeto se encontra hospedado em um servidor e é possível acessá-lo pelas seguintes URLs:

[API de cálculo de juros](http://144.22.128.149:5001/swagger/index.html)

[API de taxa de juros](http://144.22.128.149:4001/swagger/index.html)
