FROM debian:10
LABEL version="1.0" description="Dbin/Nginx"
RUN apt-get update && apt-get install -y nginx && apt-get clean
EXPOSE 88
ENTRYPOINT [ "/usr/sbin/nginx" ]
CMD ["-g","daemon off;"]