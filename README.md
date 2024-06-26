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

