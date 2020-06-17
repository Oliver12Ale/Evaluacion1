function tatMensaje(type, message) {
    var title, color = '';
    switch (type) {

        case "success":
            title = 'Confirmación';
            color = 'bg-success';
            break;
        case "information":
            title = 'Mensaje importante';
            color = 'bg-info';
            break;
        case "warning":
            title = 'Aviso importante';
            color = 'bg-warning';
            break;
        case "error":
            title = 'Alerta importante';
            color = 'bg-danger';
            break;
        default:
    }

    // Quitamos todos los estilos
    $('#toastHeader').removeClass('bg-success bg-info bg-warning bg-dange');
    $('#toastHeader').addClass(color);

    $('#toast .titulo').html(title);
    $('#toast .cuerpo').html(message);

    $('#toast').toast({
        delay: 4000
    });
    $('#toast').toast('show');
}