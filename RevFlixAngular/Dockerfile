FROM node:12.16.1-alpine as build
WORKDIR /workspace
EXPOSE 4200
EXPOSE 443
COPY . .
RUN npm ci
RUN npm run build
RUN npm run lint
CMD [ "npm", "start" ]