#!/bin/bash

dotnet publish -c Release -o ./app DataLuna.Back/DataLuna.Back.csproj

docker build -t cr.yandex/crpdcqv18l8nis2ebeu3/dtlback:1.0

docker login --username oauth --password AgAAAAARuFJyAATuwTeaZ9G5bETCkKI1ZXJ4n48 cr.yandex

docker push cr.yandex/crpdcqv18l8nis2ebeu3/dtlback:1.0

#remote host
ssh dtluser@84.201.144.34 sudo docker login --username iam --password t1.9euelZqVxpOciZeUlo6JlprGlIublu3rnpWayJ3Hi5ySncnHnpqamsuejJvl8_d6HhsB-u8PQgku_t3z9zpNGAH67w9CCS7-.xz-UV_Pd_XYRGDCsGiiRVqnw14m0RnSX1oE4-z1XrJAJ5fmuMkgK7oP4M1BkEEUtbEjM0RDErs_tKBAJgq-4BA cr.yandex

ssh dtluser@84.201.144.34 sudo docker pull cr.yandex/crpdcqv18l8nis2ebeu3/dtlback:1.0

ssh dtluser@84.201.144.34 sudo docker stop dtlback

ssh dtluser@84.201.144.34 sudo docker rm dtlback

ssh dtluser@84.201.144.34 sudo docker run -p 5000:5000 -d --name dtlback cr.yandex/crpdcqv18l8nis2ebeu3/dtlback:1.0

rm -r ./app

echo "Backend was re-deployed!"

