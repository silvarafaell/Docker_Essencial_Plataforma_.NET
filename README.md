
# Docker Essencial Plataforma .NET - Udemy 

- Docker - Uma plataforma que permite criar, enviar e executar qualquer aplicativo, em qualquer lugar.
- Docker Hub - Repositorio de imagens(baixa as imagens)
- O principal beneficio do Docker éque ele permite que os usuarios empacotem um aplicativo com todas as suas dependencias em uma unidade 
padronizada(container) para desenvolvimento de software que poderá ser executado em ambientes distintos.
- O Docker chama de conteiner um espaço reservado na memoria que é executado independentemente e isoladamente de outros conteineres ou do proprio
host

### Criando Contêineres
- Criar um contêiner no docker
  - docker container run <imagem>
  - docker container run hello-world
    
- Docker é o executor do comando
- Container indica que o comando vai atuar em um contêiner
- Run é a porta de entrada no Docker e realiza 4 operações
  - Baixa a imagem não encontrada
  - Cria o container
  - Inicializa o container
  - Uso do modo interativo
- Hello-world é a imagem existente
- docker container ps - exibe os containers em execução
- docker container ps -a - exibe todos os containers
- docker container run hello-world
- docker images
- docker container os -a
- docker image pull alpine - baixa a imagem local
- docker container run alpine ls -l(comando executado dentro do container)
- docker container run -it alpine /bin/sh - Modo interativo e abre terminal dentro do container
- docker container run --name ws1 -p 9080:80 nginx - Mapeando portas
- docker container run --name ws1 -p 9080:80 -d nginx - Executar em segundo plano
- docker container run --name demonet -it mcr.microsoft.com/dotnet/sdk:2.1 - Modo iterativo e abre o terminal
  - mkdir demo
  - cd demo
  - dotnet new console
  - dotnet build
  - dotnet run
  - docker image ls
  - docker container start -ia demonet
  - docker images
  - docker container os -a
  - docker container prune - Limpa todos os containers
  - docker images
  - docker image rm id(id da imagem)

### Imagens
- Os contêineres do Docker são baseados em imagens do docker
- Um contêiner sempre começa com uma imagem e é considerado uma instanciação dessa imagem
- A imagem seria a classe e contêiner os objetos da classe
- Uma imagem do Docker é um binário que inclui todos os requisitos para a criação e execução de um único contêiner do Docker, bem como metadados que descrevem suas necessidades e capacidades, incluindo o código do aplicativo dentro do contêiner e suas configurações
- Criar imagem
  - Usando o Dockerfile
  - Usando o comando commit
- Dockerfile é um arquivo texto com instruções, comandos e passos que é executando através do comando build para gerar uma imagem(docker build -t <imagem>)
- Criando imagens usando o Dockerfile
  -  O Docker constrói imagens automaticamente lendo as instruções a partir de um arquivo texto chamado Dockerfile
  -  O Docker file contém todos os comandos em ordem necessários para criar uma imagem. É neste arquivo que definimos todas as regras, informações e instruções que estão contidas mas imagens
  -  docker build -t franciscorafael/img:1.0 .
  -  docker images
  -  docker container run -d -p 8088:88 --name=ws5 franciscorafael/img:1.0
- Gerenciando Imagens
  - docker images
  - docker image --help
  - docker image pull --help
  - docker image pull redis - baixa a imagem latest do dockerhub
  - docker image list
  - docker image tag redis:latest redis:mac
  - docker image prune - remove todas as imagens
- Criar Imagem para a Aplicação ASP.NET Core MVC
  - 1 Publica a aplicacao
    - dotnet publish --configuration Release --output dist   - Publica a aplicação
    - configuration Release   - Indica que estamos usando o modo Release que é o modo usado na produção
    - output dist       - Indica que o projeto compilado será copiado para uma pasta dist
  - Criar arquivo Dockerfile (no raiz da app)

