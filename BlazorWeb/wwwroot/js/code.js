function applyMaskToInput(inputElement) {
    VMasker(inputElement).maskMoney({
        precision: 2,
        separator: ',',
        delimiter: '.',
        unit: 'R$'
    });
}
