@echo off
docker run -d --name redis -p 6379:6379 redis
docker run -d --name rmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management