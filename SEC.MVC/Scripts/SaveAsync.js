function SaveAsync(controller, form, callback) {
    callAsync(controller, form)
        .then(response => {
            tatMensaje("success", "Información almacenada.");
        }) //Llamada y que regrese el json
        .catch(error => {

            console.error('Error:', error);
            console.error(error.status);

            var toastMsj = 'No se pudo guardar el registro';

            if (error.status === 409) {
                toastMsj = 'No se puede guardar el registro';
            }

            tatMensaje("error", toastMsj);

        })
        .then(response => {
            callback();
            $("#exampleModal").modal("hide");
        });
}

async function callAsync(controller, form) {

    let response = await fetch(controller, {
        method: "POST",
        body: form
    });
    //debugger;
    if (response.ok) {
        return await response.json();
    } else {
        return Promise.reject({
            status: response.status,
            statusText: response.statusText
        })
    }
}