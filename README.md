
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
  - 2 Criar arquivo Dockerfile (no raiz da app)
    - Denifir uma imagem base
    - Definir informações para a imagem
    - Definir a pasta de trabalho (/app)
    - Copiar os arquivos da pasta dist para uma pasta no contêiner (/app)
    - Expor a porta do contêiner e definir em qual porta o servidor vai atender
    - Definir o ponto de entrada a aplicação
  - 3 Criar a imagem
    - docker build -t aspnetcoremvc/app1:1.0 .
    - docker build - O comando
    - -t - O parâmetro usado para informar que a imagem pertence ao usuário
    - aspnetcoremvc/app1:1.0 - O nome da imagem e a tag distribuída a imagem
    - . - o diretório atual (pois dei o build dentro da pasta do Dockerfile)
    - docker images
    - docker contêiner -a
  - 4 Criar contêiner
    - docker container create -p 3000:80 --name mvcprodutos aspnetcoremvc/app1:1.0 - criar container a partir da imagem
    - docker container start mvcprodutos   -- Vai subir como se estivesse executando o projeto
- Criar imagem ASP.NET Core MVC Ajuste .NET 6
   - 1 Publicar a aplicação na pasta dist
     - dotnet publish --configuration Release --output dist
   - 2 Criar arquivo Dockerfle
     - Usar imagem do runtime da ASP.NET Core 6
     - mcr.microsoft.com/dotnet/aspnet:6.0
     - FROM mcr.microsoft.com/dotnet/aspnet:6.0
   - 3 Criar imagem da aplicação MVC a partir do Dockerfile
     - docker build -t aspnetcoremvc/app1:1.0 .
     - docker images ls
   - 4 Criar o container a partir da imagem
     - docker container create -p 3000:80 --name mvcprodutos aspnetcoremvc/app1:1.0
   - 5 Iniciar o container
     - docker container start mvcprodutos
     - http://localhost:3000 - Abrir no navegador
- Publicar Imagens
  - 1 Criar uma conta do Docker Hub
    - http://hub.docker.com
  - 2 Preparar a imagem (tagear a imagem) para ser enviada
    - docker image tag img franciscorafael/nome:versão
    - docker image tag aspnetcoremvc/app1:1.0 franciscorafaell/mvcprodutos:1.0
    - docker image ls
  - 3 Se logar na sua conta no repositório
    - docker login -u <usurio> -p <senha>
    - docker login -u franciscorafaell
  - 4 Enviar a imagem para o repositório
    - docker image push   - imagem repositório
    - docker image push franciscorafaell/mvcprodutos:1.0

### Volumes
- Os Volumes separam os arquivos de dados que são gerados por um aplicativo ou banco de dados do restante do armazenamento do contêiner.
- Eles permitem que dados importantes existam fora do contêiner, o que significa que você pode substituir um contêiner sem perder os dados que ele criou
- Criar Volume
  - docker container run -v <pasta_host>:<pasta_container> imagem
- Criando Volumes: DataBase MySQL
  - docker volume create <nome>
  - docker volume ls
  - docker volume create dadosdb
  - docker volume ls
  - docker image pull mysql:5.7
  - docker image ls
  - docker image inspect mysql:5.7
  - docker container run -d --name mysql -v dadosdb:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=numsey mysql:5.7
  - docker container exec -it mysql /bin/bash
  - mysql -u root -p
  - show databases;
  - create database testedb;
  - show databases;

- Ajustar Aplicação MVC com EF Core e acessar MySQL
  - dotnet add package Pomelo.EntityFrameworkCore.MySql
  - dotnet add package Pomelo.EntityFrameworkCore.MySql.Design
  - dotnet add package Microsoft.EntityFramework.Tools
  - criação do arquivo de contexto
  - criação classe Repository

### Networks(Redes)
- Por padrão o Docker é disponibilizado com 3 redes que oferecem configurações especificas para gerenciar o trafego de dados
- docker network ls
- docker network inspect bridge
- Usando redes virtuais
  - docker container ps -a
  - docker container run -it --name alp1 alpine
    - hostname -i
  - docker network create --driver <nome> <nome_da_rede>
- Criando redes Customizadas no Docker
 - docker network create --driver <nome> <nome_da_rede>
 - docker network create --driver bridge rede alpine
 - docker container run -it --name alp1 --network redealpine alpine         - Criar container e associar a rede
- Escalando a aplicação MVC usando redes
  - docker container run -d --name appmvc2 -p 3500:00 -e DBHOST=172.17.0.2 produtosmvc/app:2.0
- Criando e usando redes customizadas
  - Limitações das Redes padrão(bridge)
    - A primeira limitação é o processo inadequado de inspecionar a rede para obter o endereço IP do contêiner para realizar a configuração
    - A segunda limitação é que todos os conteinere estão conectados a mesma rede, enquanto que as aplicações são em geral projetadas com múltiplas redes
    - Podemos contornar essas limitações criando redes personalizadas em vez de usar a rede padrão
  - docker network create <nome_rede>   - Cria rede personalizada
  - docker container rm -f $(docker ps -aq) Para e remover todos os contêineres
  - Criando duas novas redes personalizadas
    - docker network create frontend -> Receber requisições HTTP dos contêineres MVC
    - docker network create backed   -> Consultas SQL entre contêineres MVC e MySql
  - docker network ls

### Docker Compose
- Introdução ao Docker-Compose
  - Docker Compose que é uma ferramenta usada para descrever aplicações complexas e gerenciar os contêineres, as redes e os volumes que essas aplicações exigem para funcionar
  - Ele Simplifica o processo de configuração e execução de aplicativos para que você não precise digitar os comandos complexos, o que pode levar a erros de configuração
- Usando o Docker Compose
  - Docker Compose é o orquestrador de containers da Docker
  - 1 Definir o ambiente necessário para a sua aplicação funcionar utilizando um Dockerfile
  - 2 Criar o arquivo de composição .yml definindo quais serviços são essenciais para a sua aplicação e o relacionamento entre eles
  - 3 Processar o arquivo de composição executando o comando docker-compose para que seu ambiente seja criado e configurado
  - criando na raiz do projeto pelo o vscode docker-compose.yml
  - docker-compose -f docker-compose.yml build     processa o arquivo
- Criando o arquivo de composição
  - services: Descreve os serviços usados para criar contêineres
  - mysql - Indica o inicio da descrição de um serviço que vai criar o contêiner chamado mysql
  - image: Define a imagem Docker que sera usada para criar o contêiner
  - volumes: Especifica os volumes usados pelos contêineres e os diretórios envolvidos
  - networks - Define as redes com as quais o contêiner vai se conectar
  - environment - Define as variáveis de ambientes que serão usadas quando o contêiner for criado
  - docker-compose build        - verifica sintase
  - docker-compose up           - processa o arquivo e inicializa
  - docker container ps -a      - criou o container
  - docker network ls           - criou a network
  - docker volume ls            - criou o volume
- Ajustando a aplicação MVC: Usando script SQL
  - Execução script SQL para criação do banco de dados, sera criado na raiz do projeto e será usado no serviço para a criação do container SQL
  - docker-compose down -v  - exclui tudo o que o docker compose criou

### Desenvolvimento na plataforma .NET
- Fazendo o Deploy no Contêiner
  - docker image pull Microsoft/dotnet:2.1-sdk
  - definir o arquivo Dockerfile
  - Dockerfile.dev
  - docker-compose-dev.yml
  - docker-compose -f docker-compose-dev.yml -p dev build   - criar a imagem
  - docker-compose -f docker-compose-dev.yml -p dev up mvc  - processar o arquivo de composição

