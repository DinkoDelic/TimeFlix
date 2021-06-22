FROM node:14.16.1-alpine AS build-step
RUN mkdir -p /app
WORKDIR /app
COPY package.json /app
RUN npm install
COPY . /app
RUN npm install -g @angular/cli@11.2.6
RUN ng build --prod
EXPOSE 80
EXPOSE 443

### STAGE 2: Run ###
FROM nginx:1.17.1-alpine
COPY --from=build-step /app/dist/client /usr/share/nginx/html



