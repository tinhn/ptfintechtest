FROM node:22.5.0-alpine

# set working directory
WORKDIR /app

# install app dependencies
COPY package.json ./
COPY package-lock.json ./
RUN npm install
RUN npm audit fix --force
# RUN npm install react-scripts@5.0.1 -g --silent

# add app
COPY . ./
EXPOSE 8000
# start app
CMD ["npm", "run", "dev"]