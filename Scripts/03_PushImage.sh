# Make sure you started Minikube with the Registry addon, and made it available
# 
# macOS: docker run --rm -it --network=host alpine ash -c "apk add socat && socat TCP-LISTEN:5000,reuseaddr,fork TCP:$(minikube ip):5000"
# Windows: https://minikube.sigs.k8s.io/docs/handbook/registry/

docker push localhost:5000/kubernetesdummyapi