#!/bin/sh
set -e

apt-get update && apt-get install -y libzip-dev unzip

docker-php-ext-install pdo pdo_mysql

a2enmod rewrite

chown -R www-data:www-data /var/www/html

exec apache2-foreground
