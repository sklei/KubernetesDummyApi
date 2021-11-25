docker build -t localhost:5000/kubernetesdummyapi ./Api/
docker push localhost:5000/kubernetesdummyapi
kubectl apply -f ./Charts/simple/pvc.yaml
kubectl apply -f ./Charts/simple/deployment.yaml
kubectl apply -f ./Charts/simple/service.yaml
kubectl rollout restart deployment kubernetesdummyapi-simple