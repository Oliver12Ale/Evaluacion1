var urlDelete; //Controlador 
var idDelete; //Registro a eliminar


var DeleteAsync = function (event) {
    event.preventDefault();

    let target = event.target;
    let element = target.dataset.element;
    idDelete = target.dataset.id;


    document.getElementById('delete-modal-title').innerHTML = `Eliminar ${entity}`;
    document.getElementById('delete-body-message').innerHTML = `¿Seguro de eliminar el elemento ${element}?`
    urlDelete = `${window.location.origin}/${controller}/DeleteAsync`;

    $("#deleteModal").modal('show');

};

//click eliminar
document.querySelector('#confirm-delete').addEventListener('click', function (e) {
    e.preventDefault();
    confirmDelete(reloadTable);
});

function confirmDelete(callback) {
    callDeleteAsync()
        .then(response => {
            tatMensaje("information", "Registro Eliminado.");
        }) //Llamada y que regrese el json
        .catch(error => {
            console.error('Error:', error);
            var toastMsj = 'No se elimino el registro';
            if (error.status === 409) {
                toastMsj = 'No se puede eliminar el registro';
            }

            tatMensaje("warning", toastMsj);
        })
        .then(response => {
            callback();
            $("#deleteModal").modal('hide');
        });
}

async function callDeleteAsync() {
    const formData = new FormData();
    formData.append('id', idDelete);

    let response = await fetch(urlDelete, {
        method: "POST",
        body: formData
    });

    if (response.ok) {
        return await response.json();
    } else {
        return Promise.reject({
            status: response.status,
            statusText: response.statusText
        })
    }
}