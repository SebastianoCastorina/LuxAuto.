// Funzione per gestire il caricamento delle immagini
function handleFileSelect(evt) {
    var files = evt.target.files; // Ottieni i file selezionati

    for (var i = 0, f; f = files[i]; i++) {
        if (!f.type.match('image.*')) {
            continue;
        }

        var reader = new FileReader();

        // Leggi il file
        reader.onload = (function (theFile) {
            return function (e) {
                // Crea un'immagine miniatura
                var thumbnail = document.createElement('img');
                thumbnail.className = 'miniatura';
                thumbnail.src = e.target.result;

                // Aggiungi la miniatura al div delle miniature
                document.getElementById('miniature').appendChild(thumbnail);
            };
        })(f);

        reader.readAsDataURL(f);
    }
}

// Ascolta l'evento di cambio del file input
document.getElementById('Foto').addEventListener('change', handleFileSelect, false);
document.getElementById('Foto1').addEventListener('change', handleFileSelect, false);
document.getElementById('Foto2').addEventListener('change', handleFileSelect, false);
document.getElementById('Foto3').addEventListener('change', handleFileSelect, false);
document.getElementById('Foto4').addEventListener('change', handleFileSelect, false);
document.getElementById('Foto5').addEventListener('change', handleFileSelect, false);
document.getElementById('Foto6').addEventListener('change', handleFileSelect, false);





document.addEventListener('DOMContentLoaded', function () {
    const carousel = new bootstrap.Carousel(document.getElementById('carousel-@item.idAuto'));
});

$(document).ready(function () {
    // Inizializza il carosello
    $('.carousel').carousel();

    // Aggiungi un gestore per l'evento 'slid.bs.carousel' che si verifica dopo ogni scorrimento del carosello
    $('.carousel').on('slid.bs.carousel', function () {
        var $carousel = $(this);
        var $activeItem = $carousel.find('.carousel-item.active');

        // Verifica se l'utente ha scorso tutte le immagini manualmente
        if ($activeItem.is(':last-child')) {
            // Rimuovi l'immagine fissa dal carosello
            $carousel.find('.carousel-item.d-none').remove();
        }
    });
});


$(document).ready(function () {
    $.ajax({
        url: '/Marchio/GetMarchiDistincti',
        type: 'GET',
        success: function (data) {
            $.each(data, function (index, item) {
                $('#selectedMarchio').append($('<option>', {
                    value: item,
                    text: item
                }));
            });
        }
    });
});

function openFullScreen(imagePath) {
    var modal = document.createElement('div');
    modal.className = 'fullscreen-modal';
    document.body.appendChild(modal);

    var img = document.createElement('img');
    img.src = imagePath;
    img.className = 'fullscreen-image';
    modal.appendChild(img);

    modal.onclick = function () {
        document.body.removeChild(modal);
    };
}

$(document).ready(function () {
 
    $("#betInput").on("input", function () {
      
        var betValue = $(this).val();

        var linkHref = $("#betLink").attr("href");

      
        var newUrl = linkHref + "?Bet=" + betValue;

    
        $("#betLink").attr("href", newUrl);
    });
});

function aggiornaUltimaOfferta() {
    $.ajax({
        url: '/Asta/OttieniUltimaOfferta',  // Sostituisci con il percorso corretto del tuo controller/azione
        method: 'GET',
        success: function (data) {
            // Aggiorna il valore sull'elemento con id "ultimaOffertaSpan"
            $('#ultimaOffertaSpan').text('€ ' + data);
        },
        error: function (error) {
            console.error('Errore durante il recupero dell\'ultima offerta:', error);
        }
    });
}