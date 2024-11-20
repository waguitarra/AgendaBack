use agendamento;

INSERT INTO TipoServico (Id, CreateAt, UpdateAt, TipoCategoria, Descricao, UrlImagens, Ativo, Tipo, Pais) 
VALUES
-- Português
(UUID(), NOW(), NOW(), 'Clínica', 'Serviço oferecido por clínicas médicas', 'url_imagem_clinica_pt.jpg', 1, 1, 'pt'),
(UUID(), NOW(), NOW(), 'Consultório', 'Serviço oferecido por consultórios odontológicos', 'url_imagem_consultorio_pt.jpg', 1, 1, 'pt'),

-- Espanhol
(UUID(), NOW(), NOW(), 'Clínica', 'Servicio ofrecido por clínicas médicas', 'url_imagem_clinica_es.jpg', 1, 1, 'es'),
(UUID(), NOW(), NOW(), 'Consultório', 'Servicio ofrecido por consultorios odontológicos', 'url_imagem_consultorio_es.jpg', 1, 1, 'es');



SELECT * FROM agendamento.tiposervico;