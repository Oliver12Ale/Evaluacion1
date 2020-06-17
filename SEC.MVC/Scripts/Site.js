function reloadTable() {
    let table = $('#tblEntities').DataTable();
    let info = table.page.info();
    table.ajax.reload();
    table.page(info.page).draw(false);
}