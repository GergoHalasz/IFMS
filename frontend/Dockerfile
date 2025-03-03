# Build Stage
FROM node:20 AS build
WORKDIR /app

# Copy package.json and install dependencies
COPY package.json package-lock.json ./
RUN npm install

# Copy the rest of the app and build it
COPY . .
RUN npm run build

# Copy the SSL certificates
COPY ./certs /certs

# Set environment variables for HTTPS
ENV HTTPS=true
ENV SSL_CRT_FILE=/certs/cert.pem
ENV SSL_KEY_FILE=/certs/key.pem

# Serve Stage - Using Nginx
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 3000
CMD ["nginx", "-g", "daemon off;"]
