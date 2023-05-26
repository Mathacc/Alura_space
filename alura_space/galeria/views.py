from django.shortcuts import render, get_object_or_404
from galeria.models import Fotografia

def index(request):
    fotografias = Fotografia.objects.filter(publicada=True)
    return render(request, 'galeria/index.html', {"cards": fotografias})

def imagem(request, foto_id):
    fotografia = get_object_or_404(Fotografia, pk=foto_id)
    return render(request, 'galeria/imagem.html', {"fotografia": fotografia})

def buscar(request):
    fotografias = Fotografia.objects.order_by("nome").filter(publicada=True)

    if "buscar" in request.GET:
        searched_name = request.GET['buscar']
        if searched_name:
            fotografias = fotografias.filter(nome__icontains=searched_name)
    return render(request, "galeria/buscar.html", {"cards": fotografias})