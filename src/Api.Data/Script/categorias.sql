
use AgentesAgendamento;


SELECT * FROM categoria;

INSERT INTO categoria (Id, CreateAt, UpdateAt, TipoCategoria, Descricao, UrlImagens, Ativo, Tipo, Pais)
VALUES
(UUID(), NOW(), NOW(), 'Médico', 'Clínicas Médicas', 'url_medico.jpg', 1, 1, 'br'),
(UUID(), NOW(), NOW(), 'Médico', 'Clínicas Médicas', 'url_medico.jpg', 1, 1, 'es'),

(UUID(), NOW(), NOW(), 'Dentista', 'Consultórios Odontológicos', 'url_dentista.jpg', 1, 2, 'br'),
(UUID(), NOW(), NOW(), 'Dentista', 'Consultorios Odontológicos', 'url_dentista.jpg', 1, 2, 'es'),

(UUID(), NOW(), NOW(), 'Fisioterapeuta', 'Fisioterapia', 'url_fisioterapia.jpg', 1, 3, 'br'),
(UUID(), NOW(), NOW(), 'Fisioterapeuta', 'Fisioterapia', 'url_fisioterapia.jpg', 1, 3, 'es'),

(UUID(), NOW(), NOW(), 'Psicólogo', 'Psicologia', 'url_psicologo.jpg', 1, 4, 'br'),
(UUID(), NOW(), NOW(), 'Psicólogo', 'Psicología', 'url_psicologo.jpg', 1, 4, 'es'),

(UUID(), NOW(), NOW(), 'Nutricionista', 'Nutrição', 'url_nutricionista.jpg', 1, 5, 'br'),
(UUID(), NOW(), NOW(), 'Nutricionista', 'Nutrición', 'url_nutricionista.jpg', 1, 5, 'es'),

(UUID(), NOW(), NOW(), 'Personal Trainer', 'Personal Trainer', 'url_personal_trainer.jpg', 1, 6, 'br'),
(UUID(), NOW(), NOW(), 'Entrenador Personal', 'Entrenador Personal', 'url_personal_trainer.jpg', 1, 6, 'es'),

(UUID(), NOW(), NOW(), 'Massoterapeuta', 'Massoterapia', 'url_massoterapeuta.jpg', 1, 7, 'br'),
(UUID(), NOW(), NOW(), 'Masoterapeuta', 'Masoterapia', 'url_massoterapeuta.jpg', 1, 7, 'es'),

(UUID(), NOW(), NOW(), 'Esteticista', 'Estética Facial e Corporal', 'url_esteticista.jpg', 1, 8, 'br'),
(UUID(), NOW(), NOW(), 'Esteticista', 'Estética Facial y Corporal', 'url_esteticista.jpg', 1, 8, 'es'),

(UUID(), NOW(), NOW(), 'Terapeuta Holístico', 'Terapias Holísticas', 'url_terapeuta_holistico.jpg', 1, 9, 'br'),
(UUID(), NOW(), NOW(), 'Terapeuta Holístico', 'Terapias Holísticas', 'url_terapeuta_holistico.jpg', 1, 9, 'es'),

(UUID(), NOW(), NOW(), 'Instrutor de Yoga', 'Centros de Yoga e Meditação', 'url_instrutor_yoga.jpg', 1, 10, 'br'),
(UUID(), NOW(), NOW(), 'Instructor de Yoga', 'Centros de Yoga y Meditación', 'url_instrutor_yoga.jpg', 1, 10, 'es');


INSERT INTO categoria (Id, CreateAt, UpdateAt, TipoCategoria, Descricao, UrlImagens, Ativo, Tipo, Pais)
VALUES
(UUID(), NOW(), NOW(), 'Cabeleireiro e Barbeiro', 'Cabeleireiro e Barbeiro', 'url_cabeleireiro_barbeiro.jpg', 1, 11, 'br'),
(UUID(), NOW(), NOW(), 'Peluquero y Barbero', 'Peluquería y Barbería', 'url_peluquero_barbero.jpg', 1, 11, 'es'),

(UUID(), NOW(), NOW(), 'Manicure e Pedicure', 'Manicure e Pedicure', 'url_manicure_pedicure.jpg', 1, 12, 'br'),
(UUID(), NOW(), NOW(), 'Manicurista y Pedicurista', 'Manicura y Pedicura', 'url_manicura_pedicura.jpg', 1, 12, 'es'),

(UUID(), NOW(), NOW(), 'Especialista em Depilação', 'Depilação', 'url_depilacao.jpg', 1, 13, 'br'),
(UUID(), NOW(), NOW(), 'Especialista en Depilación', 'Depilación', 'url_depilacion.jpg', 1, 13, 'es'),

(UUID(), NOW(), NOW(), 'Estilista de Beleza', 'Salões de Beleza', 'url_saloes_beleza.jpg', 1, 14, 'br'),
(UUID(), NOW(), NOW(), 'Estilista de Belleza', 'Salones de Belleza', 'url_salones_belleza.jpg', 1, 14, 'es'),

(UUID(), NOW(), NOW(), 'Maquiador Profissional', 'Maquiadores Profissionais', 'url_maquiadores_profissionais.jpg', 1, 15, 'br'),
(UUID(), NOW(), NOW(), 'Maquillador Profesional', 'Maquilladores Profesionales', 'url_maquilladores_profesionales.jpg', 1, 15, 'es'),

(UUID(), NOW(), NOW(), 'Designer de Sobrancelhas', 'Design de Sobrancelhas', 'url_design_sobrancelhas.jpg', 1, 16, 'br'),
(UUID(), NOW(), NOW(), 'Diseñador de Cejas', 'Diseño de Cejas', 'url_diseno_cejass.jpg', 1, 16, 'es'),

(UUID(), NOW(), NOW(), 'Especialista em Extensão de Cílios', 'Extensão de Cílios', 'url_extensao_cilios.jpg', 1, 17, 'br'),
(UUID(), NOW(), NOW(), 'Especialista en Extensión de Pestañas', 'Extensión de Pestañas', 'url_extension_pestanas.jpg', 1, 17, 'es'),

(UUID(), NOW(), NOW(), 'Especialista em Bronzeamento', 'Bronzeamento Artificial', 'url_bronzeamento_artificial.jpg', 1, 18, 'br'),
(UUID(), NOW(), NOW(), 'Especialista en Bronceado', 'Bronceado Artificial', 'url_bronceado_artificial.jpg', 1, 18, 'es'),

(UUID(), NOW(), NOW(), 'Especialista em Spas e Estética', 'Spas e Clínicas de Estética', 'url_spas_clinicas_estetica.jpg', 1, 19, 'br'),
(UUID(), NOW(), NOW(), 'Especialista en Spas y Estética', 'Spas y Clínicas de Estética', 'url_spas_clinicas_estetica.jpg', 1, 19, 'es');


INSERT INTO Categoria (Id, CreateAt, UpdateAt, TipoCategoria, Descricao, UrlImagens, Ativo, Tipo, Pais)
VALUES
-- Serviços Gerais
(UUID(), NOW(), NOW(), 'Mecânico', 'Especialista em manutenção e reparos automotivos', 'url_mecanico_pt.jpg', 1, 20, 'br'),
(UUID(), NOW(), NOW(), 'Mecánico', 'Especialista en mantenimiento y reparaciones automotrices', 'url_mecanico_es.jpg', 1, 20, 'es'),

(UUID(), NOW(), NOW(), 'Eletricista', 'Especialista em serviços elétricos', 'url_eletricista_pt.jpg', 1, 21, 'br'),
(UUID(), NOW(), NOW(), 'Electricista', 'Especialista en servicios eléctricos', 'url_eletricista_es.jpg', 1, 21, 'es'),

(UUID(), NOW(), NOW(), 'Encanador', 'Especialista em serviços hidráulicos', 'url_encanador_pt.jpg', 1, 22, 'br'),
(UUID(), NOW(), NOW(), 'Fontanero', 'Especialista en servicios hidráulicos', 'url_encanador_es.jpg', 1, 22, 'es'),

(UUID(), NOW(), NOW(), 'Pintor', 'Especialista em pintura residencial e comercial', 'url_pintor_pt.jpg', 1, 23, 'br'),
(UUID(), NOW(), NOW(), 'Pintor', 'Especialista en pintura residencial y comercial', 'url_pintor_es.jpg', 1, 23, 'es'),

(UUID(), NOW(), NOW(), 'Técnico de TI', 'Especialista em suporte técnico e TI', 'url_tecnico_ti_pt.jpg', 1, 24, 'br'),
(UUID(), NOW(), NOW(), 'Técnico de TI', 'Especialista en soporte técnico e TI', 'url_tecnico_ti_es.jpg', 1, 24, 'es'),

(UUID(), NOW(), NOW(), 'Instrutor', 'Especialista em cursos livres e treinamentos', 'url_instrutor_pt.jpg', 1, 25, 'br'),
(UUID(), NOW(), NOW(), 'Instructor', 'Especialista en cursos libres y entrenamientos', 'url_instrutor_es.jpg', 1, 25, 'es'),

(UUID(), NOW(), NOW(), 'Técnico em Ar-Condicionado', 'Especialista em instalação e manutenção de ar-condicionado', 'url_tecnico_ar_condicionado_pt.jpg', 1, 26, 'br'),
(UUID(), NOW(), NOW(), 'Técnico en Aire Acondicionado', 'Especialista en instalación y mantenimiento de aire acondicionado', 'url_tecnico_ar_condicionado_es.jpg', 1, 26, 'es'),

(UUID(), NOW(), NOW(), 'Engenheiro Civil', 'Especialista em construção civil e reformas', 'url_engenheiro_civil_pt.jpg', 1, 27, 'br'),
(UUID(), NOW(), NOW(), 'Ingeniero Civil', 'Especialista en construcción civil y reformas', 'url_engenheiro_civil_es.jpg', 1, 27, 'es'),

(UUID(), NOW(), NOW(), 'Jardineiro', 'Especialista em serviços de jardinagem', 'url_jardineiro_pt.jpg', 1, 28, 'br'),
(UUID(), NOW(), NOW(), 'Jardinero', 'Especialista en servicios de jardinería', 'url_jardineiro_es.jpg', 1, 28, 'es'),

(UUID(), NOW(), NOW(), 'Fotógrafo', 'Especialista em ensaios fotográficos e serviços de fotografia', 'url_fotografo_pt.jpg', 1, 29, 'br'),
(UUID(), NOW(), NOW(), 'Fotógrafo', 'Especialista en servicios de fotografía y ensayos', 'url_fotografo_es.jpg', 1, 29, 'es'),

(UUID(), NOW(), NOW(), 'Videomaker', 'Especialista em gravações e produção de vídeos', 'url_videomaker_pt.jpg', 1, 30, 'br'),
(UUID(), NOW(), NOW(), 'Videógrafo', 'Especialista en grabación y producción de vídeos', 'url_videomaker_es.jpg', 1, 30, 'es'),

(UUID(), NOW(), NOW(), 'DJ', 'Especialista em serviços de DJs para eventos', 'url_dj_pt.jpg', 1, 31, 'br'),
(UUID(), NOW(), NOW(), 'DJ', 'Especialista en servicios de DJs para eventos', 'url_dj_es.jpg', 1, 31, 'es'),

(UUID(), NOW(), NOW(), 'Organizador', 'Especialista em organização de espaços e personal organizers', 'url_organizador_pt.jpg', 1, 32, 'br'),
(UUID(), NOW(), NOW(), 'Organizador', 'Especialista en organización de espacios y personal organizers', 'url_organizador_es.jpg', 1, 32, 'es'),

(UUID(), NOW(), NOW(), 'Instrutor de Trânsito', 'Especialista em formação de condutores', 'url_instrutor_transito_pt.jpg', 1, 33, 'br'),
(UUID(), NOW(), NOW(), 'Instructor de Tráfico', 'Especialista en formación de conductores', 'url_instrutor_transito_es.jpg', 1, 33, 'es'),

(UUID(), NOW(), NOW(), 'Consultor de Beleza', 'Especialista em consultoria de beleza e cosméticos', 'url_consultor_beleza_pt.jpg', 1, 34, 'br'),
(UUID(), NOW(), NOW(), 'Consultor de Belleza', 'Especialista en consultoría de belleza y cosméticos', 'url_consultor_beleza_es.jpg', 1, 34, 'es'),

(UUID(), NOW(), NOW(), 'Agente de Turismo', 'Especialista em pacotes e guias turísticos', 'url_agente_turismo_pt.jpg', 1, 35, 'br'),
(UUID(), NOW(), NOW(), 'Agente de Turismo', 'Especialista en paquetes y guías turísticos', 'url_agente_turismo_es.jpg', 1, 35, 'es'),

(UUID(), NOW(), NOW(), 'Babá', 'Especialista em cuidados infantis', 'url_baba_pt.jpg', 1, 36, 'br'),
(UUID(), NOW(), NOW(), 'Niñera', 'Especialista en cuidado infantil', 'url_baba_es.jpg', 1, 36, 'es'),

(UUID(), NOW(), NOW(), 'Cuidador de Idosos', 'Especialista em cuidados para idosos', 'url_cuidador_idosos_pt.jpg', 1, 37, 'br'),
(UUID(), NOW(), NOW(), 'Cuidador de Ancianos', 'Especialista en cuidado de ancianos', 'url_cuidador_idosos_es.jpg', 1, 37, 'es');


-- Continue para os outros serviços seguindo o mesmo padrão.
