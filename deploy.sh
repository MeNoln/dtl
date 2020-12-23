#!/bin/bash

dotnet publish -c Release -o ./app DataLuna.Back/DataLuna.Back.csproj

docker build . -t cr.yandex/crpdcqv18l8nis2ebeu3/dtlback:1.0

docker login --username oauth --password AgAAAAARuFJyAATuwTeaZ9G5bETCkKI1ZXJ4n48 cr.yandex

docker push cr.yandex/crpdcqv18l8nis2ebeu3/dtlback:1.0

#remote host
IAM_TOKEN=$(yc iam create-token)

ssh dtluser@84.201.169.39 sudo docker login --username iam --password $IAM_TOKEN cr.yandex

ssh dtluser@84.201.169.39 sudo docker pull cr.yandex/crpdcqv18l8nis2ebeu3/dtlback:1.0

ssh dtluser@84.201.169.39 sudo docker stop dtlback

ssh dtluser@84.201.169.39 sudo docker rm dtlback

ssh dtluser@84.201.169.39 sudo docker run -p 5000:5000 -d --name dtlback cr.yandex/crpdcqv18l8nis2ebeu3/dtlback:1.0

rm -r ./app

echo "Backend was re-deployed!"

