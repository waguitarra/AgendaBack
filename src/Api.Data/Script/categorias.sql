
use agendamento;

INSERT INTO Categoria (Id, CreateAt, UpdateAt, TipoCategoria, Descricao, UrlImagens, Ativo, Tipo, Pais) 
VALUES
(UUID(), NOW(), NOW(), 'Médico', 'Categoria para profissionais da área médica', 'url_imagem_medico_pt.jpg', 1, 1, 'Brasil'),
(UUID(), NOW(), NOW(), 'Dentista', 'Categoria para profissionais da área odontológica', 'url_imagem_dentista_pt.jpg', 1, 1, 'Brasil'),
(UUID(), NOW(), NOW(), 'Médico', 'Categoría para profesionales del área médica', 'url_imagem_medico_es.jpg', 1, 1, 'Espanha'),
(UUID(), NOW(), NOW(), 'Dentista', 'Categoría para profesionales del área odontológica', 'url_imagem_dentista_es.jpg', 1, 1, 'Espanha');




SELECT * FROM agendamento.categoria;