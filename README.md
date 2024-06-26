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


