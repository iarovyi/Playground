FROM alpine
LABEL maintainer="my@email.com"
RUN apk add --update nodejs-npm
COPY . /src
WORKDIR /src
RUN npm install
EXPOSE 8080
ENTRYPOINT ["node", "./app.js"]