use agendamento;

INSERT INTO TipoServico (Id, CreateAt, UpdateAt, TipoCategoria, Descricao, UrlImagens,  Tipo, Ativo, Pais) 
VALUES
-- Saúde e Bem-Estar
(UUID(), NOW(), NOW(), 'Clínicas Médicas', 'Clínicas médicas gerais', 'url_clinica_medica_pt.jpg', 1, 1, 'br'),
(UUID(), NOW(), NOW(), 'Consultórios Odontológicos', 'Consultórios especializados em odontologia', 'url_consultorio_odontologico_pt.jpg', 2, 1, 'br'),
(UUID(), NOW(), NOW(), 'Fisioterapia', 'Clínicas especializadas em fisioterapia', 'url_fisioterapia_pt.jpg', 3, 1, 'br'),
(UUID(), NOW(), NOW(), 'Psicologia', 'Consultórios de psicologia', 'url_psicologia_pt.jpg', 4, 1, 'br'),
(UUID(), NOW(), NOW(), 'Nutrição', 'Consultórios de nutrição', 'url_nutricao_pt.jpg', 5, 1, 'br'),
(UUID(), NOW(), NOW(), 'Personal Trainer', 'Serviços de personal trainer', 'url_personal_trainer_pt.jpg', 6, 1, 'br'),
(UUID(), NOW(), NOW(), 'Massoterapia', 'Serviços de massoterapia', 'url_massoterapia_pt.jpg', 7, 1, 'br'),
(UUID(), NOW(), NOW(), 'Estética Facial e Corporal', 'Clínicas de estética facial e corporal', 'url_estetica_facial_corporal_pt.jpg', 8, 1, 'br'),
(UUID(), NOW(), NOW(), 'Terapias Holísticas', 'Serviços de terapias holísticas como reiki e acupuntura', 'url_terapias_holisticas_pt.jpg', 9, 1, 'br'),
(UUID(), NOW(), NOW(), 'Centros de Yoga e Meditação', 'Centros especializados em yoga e meditação', 'url_yoga_meditacao_pt.jpg', 10, 1, 'br'),

(UUID(), NOW(), NOW(), 'Clínicas Médicas', 'Clínicas médicas generales', 'url_clinica_medica_es.jpg', 1, 1, 'es'),
(UUID(), NOW(), NOW(), 'Consultorios Odontológicos', 'Consultorios especializados en odontología', 'url_consultorio_odontologico_es.jpg', 2, 1, 'es'),
(UUID(), NOW(), NOW(), 'Fisioterapia', 'Clínicas especializadas en fisioterapia', 'url_fisioterapia_es.jpg', 3, 1, 'es'),
(UUID(), NOW(), NOW(), 'Psicología', 'Consultorios de psicología', 'url_psicologia_es.jpg', 4, 1, 'es'),
(UUID(), NOW(), NOW(), 'Nutrición', 'Consultorios de nutrición', 'url_nutricao_es.jpg', 5, 1, 'es'),
(UUID(), NOW(), NOW(), 'Entrenador Personal', 'Servicios de entrenador personal', 'url_personal_trainer_es.jpg', 6, 1, 'es'),
(UUID(), NOW(), NOW(), 'Masoterapia', 'Servicios de masoterapia', 'url_massoterapia_es.jpg', 7, 1, 'es'),
(UUID(), NOW(), NOW(), 'Estética Facial y Corporal', 'Clínicas de estética facial y corporal', 'url_estetica_facial_corporal_es.jpg', 8, 1, 'es'),
(UUID(), NOW(), NOW(), 'Terapias Holísticas', 'Servicios de terapias holísticas como reiki e acupuntura', 'url_terapias_holisticas_es.jpg', 9, 1, 'es'),
(UUID(), NOW(), NOW(), 'Centros de Yoga y Meditación', 'Centros especializados en yoga y meditación', 'url_yoga_meditacao_es.jpg', 10, 1, 'es'),

-- Beleza e Estética
(UUID(), NOW(), NOW(), 'Cabeleireiro e Barbeiro', 'Serviços de cabeleireiro e barbeiro', 'url_cabeleireiro_barbeiro_pt.jpg', 11, 1, 'br'),
(UUID(), NOW(), NOW(), 'Manicure e Pedicure', 'Serviços de manicure e pedicure', 'url_manicure_pedicure_pt.jpg', 12, 1, 'br'),
(UUID(), NOW(), NOW(), 'Depilação', 'Serviços de depilação', 'url_depilacao_pt.jpg', 13, 1, 'br'),
(UUID(), NOW(), NOW(), 'Salões de Beleza', 'Serviços em salões de beleza', 'url_saloes_beleza_pt.jpg', 14, 1, 'br'),
(UUID(), NOW(), NOW(), 'Maquiadores Profissionais', 'Serviços de maquiadores profissionais', 'url_maquiadores_profissionais_pt.jpg', 15, 1, 'br'),
(UUID(), NOW(), NOW(), 'Design de Sobrancelhas', 'Serviços de design de sobrancelhas', 'url_design_sobrancelhas_pt.jpg', 16, 1, 'br'),
(UUID(), NOW(), NOW(), 'Extensão de Cílios', 'Serviços de extensão de cílios', 'url_extensao_cilios_pt.jpg', 17, 1, 'br'),
(UUID(), NOW(), NOW(), 'Bronzeamento Artificial', 'Serviços de bronzeamento artificial', 'url_bronzeamento_artificial_pt.jpg', 18, 1, 'br'),
(UUID(), NOW(), NOW(), 'Spas e Clínicas de Estética', 'Serviços em spas e clínicas de estética', 'url_spas_estetica_pt.jpg', 19, 1, 'br'),

(UUID(), NOW(), NOW(), 'Peluquería y Barbería', 'Servicios de peluquería y barbería', 'url_cabeleireiro_barbeiro_es.jpg', 11, 1, 'es'),
(UUID(), NOW(), NOW(), 'Manicura y Pedicura', 'Servicios de manicura y pedicura', 'url_manicure_pedicure_es.jpg', 12, 1, 'es'),
(UUID(), NOW(), NOW(), 'Depilación', 'Servicios de depilación', 'url_depilacao_es.jpg', 13, 1, 'es'),
(UUID(), NOW(), NOW(), 'Salones de Belleza', 'Servicios en salones de belleza', 'url_saloes_beleza_es.jpg', 14, 1, 'es'),
(UUID(), NOW(), NOW(), 'Maquilladores Profesionales', 'Servicios de maquilladores profesionales', 'url_maquiadores_profissionais_es.jpg', 15, 1, 'es'),
(UUID(), NOW(), NOW(), 'Diseño de Cejas', 'Servicios de diseño de cejas', 'url_design_sobrancelhas_es.jpg', 16, 1, 'es'),
(UUID(), NOW(), NOW(), 'Extensión de Pestañas', 'Servicios de extensión de pestañas', 'url_extensao_cilios_es.jpg', 17, 1, 'es'),
(UUID(), NOW(), NOW(), 'Bronceado Artificial', 'Servicios de bronceado artificial', 'url_bronzeamento_artificial_es.jpg', 18, 1, 'es'),
(UUID(), NOW(), NOW(), 'Spas y Clínicas de Estética', 'Servicios en spas y clínicas de estética', 'url_spas_estetica_es.jpg', 19, 1, 'es');


INSERT INTO TipoServico (Id, CreateAt, UpdateAt, TipoCategoria, Descricao, UrlImagens, Ativo, Tipo, Pais) 
VALUES
(UUID(), NOW(), NOW(), 'Oficinas Mecânicas', 'Oficinas especializadas em manutenção e reparos automotivos', 'url_oficinas_mecanicas_pt.jpg', 1, 20, 'br'),
(UUID(), NOW(), NOW(), 'Talleres Mecánicos', 'Talleres especializados en mantenimiento y reparaciones automotrices', 'url_oficinas_mecanicas_es.jpg', 1, 20, 'es'),

(UUID(), NOW(), NOW(), 'Serviços Elétricos', 'Locais especializados em serviços elétricos', 'url_servicos_eletricos_pt.jpg', 1, 21, 'br'),
(UUID(), NOW(), NOW(), 'Servicios Eléctricos', 'Locales especializados en servicios eléctricos', 'url_servicos_eletricos_es.jpg', 1, 21, 'es'),

(UUID(), NOW(), NOW(), 'Serviços Hidráulicos', 'Locais especializados em serviços hidráulicos', 'url_servicos_hidraulicos_pt.jpg', 1, 22, 'br'),
(UUID(), NOW(), NOW(), 'Servicios Hidráulicos', 'Locales especializados en servicios hidráulicos', 'url_servicos_hidraulicos_es.jpg', 1, 22, 'es'),

(UUID(), NOW(), NOW(), 'Empresas de Pintura', 'Empresas especializadas em pintura residencial e comercial', 'url_empresas_pintura_pt.jpg', 1, 23, 'br'),
(UUID(), NOW(), NOW(), 'Empresas de Pintura', 'Empresas especializadas en pintura residencial y comercial', 'url_empresas_pintura_es.jpg', 1, 23, 'es'),

(UUID(), NOW(), NOW(), 'Serviços de TI', 'Locais especializados em suporte técnico e TI', 'url_servicos_ti_pt.jpg', 1, 24, 'br'),
(UUID(), NOW(), NOW(), 'Servicios de TI', 'Locales especializados en soporte técnico e TI', 'url_servicos_ti_es.jpg', 1, 24, 'es'),

(UUID(), NOW(), NOW(), 'Centros de Formação', 'Locais para cursos livres e treinamentos', 'url_centros_formacao_pt.jpg', 1, 25, 'br'),
(UUID(), NOW(), NOW(), 'Centros de Formación', 'Locales para cursos libres y entrenamientos', 'url_centros_formacao_es.jpg', 1, 25, 'es'),

(UUID(), NOW(), NOW(), 'Serviços de Ar-Condicionado', 'Locais especializados em instalação e manutenção de ar-condicionado', 'url_servicos_ar_condicionado_pt.jpg', 1, 26, 'br'),
(UUID(), NOW(), NOW(), 'Servicios de Aire Acondicionado', 'Locales especializados en instalación y mantenimiento de aire acondicionado', 'url_servicos_ar_condicionado_es.jpg', 1, 26, 'es'),

(UUID(), NOW(), NOW(), 'Empresas de Construção', 'Empresas de construção civil e reformas', 'url_empresas_construcao_pt.jpg', 1, 27, 'br'),
(UUID(), NOW(), NOW(), 'Empresas de Construcción', 'Empresas de construcción civil y reformas', 'url_empresas_construcao_es.jpg', 1, 27, 'es'),

(UUID(), NOW(), NOW(), 'Empresas de Jardinagem', 'Locais especializados em serviços de jardinagem', 'url_empresas_jardinagem_pt.jpg', 1, 28, 'br'),
(UUID(), NOW(), NOW(), 'Empresas de Jardinería', 'Locales especializados en servicios de jardinería', 'url_empresas_jardinagem_es.jpg', 1, 28, 'es'),

(UUID(), NOW(), NOW(), 'Estúdios de Fotografia', 'Locais especializados em ensaios fotográficos e serviços de fotografia', 'url_estudios_fotografia_pt.jpg', 1, 29, 'br'),
(UUID(), NOW(), NOW(), 'Estudios Fotográficos', 'Locales especializados en servicios de fotografía y ensayos', 'url_estudios_fotografia_es.jpg', 1, 29, 'es'),

(UUID(), NOW(), NOW(), 'Estúdios de Vídeo', 'Locais especializados em gravações e produção de vídeos', 'url_estudios_video_pt.jpg', 1, 30, 'br'),
(UUID(), NOW(), NOW(), 'Estudios de Vídeo', 'Locales especializados en grabación y producción de vídeos', 'url_estudios_video_es.jpg', 1, 30, 'es'),

(UUID(), NOW(), NOW(), 'Serviços de DJ', 'Locais para serviços de DJs para eventos', 'url_servicos_dj_pt.jpg', 1, 31, 'br'),
(UUID(), NOW(), NOW(), 'Servicios de DJ', 'Locales para servicios de DJs para eventos', 'url_servicos_dj_es.jpg', 1, 31, 'es'),

(UUID(), NOW(), NOW(), 'Serviços de Organização', 'Locais especializados em organização de espaços e personal organizers', 'url_servicos_organizacao_pt.jpg', 1, 32, 'br'),
(UUID(), NOW(), NOW(), 'Servicios de Organización', 'Locales especializados en organización de espacios y personal organizers', 'url_servicos_organizacao_es.jpg', 1, 32, 'es'),

(UUID(), NOW(), NOW(), 'Escolas de Condução', 'Escolas especializadas em formação de condutores', 'url_escolas_conducao_pt.jpg', 1, 33, 'br'),
(UUID(), NOW(), NOW(), 'Escuelas de Conducción', 'Escuelas especializadas en formación de conductores', 'url_escolas_conducao_es.jpg', 1, 33, 'es'),

(UUID(), NOW(), NOW(), 'Consultoria de Beleza', 'Locais especializados em consultoria de beleza e cosméticos', 'url_consultoria_beleza_pt.jpg', 1, 34, 'br'),
(UUID(), NOW(), NOW(), 'Consultoría de Belleza', 'Locales especializados en consultoría de belleza y cosméticos', 'url_consultoria_beleza_es.jpg', 1, 34, 'es'),

(UUID(), NOW(), NOW(), 'Agências de Turismo', 'Agências especializadas em pacotes e guias turísticos', 'url_agencias_turismo_pt.jpg', 1, 35, 'br'),
(UUID(), NOW(), NOW(), 'Agencias de Turismo', 'Agencias especializadas en paquetes y guías turísticos', 'url_agencias_turismo_es.jpg', 1, 35, 'es'),

(UUID(), NOW(), NOW(), 'Serviços de Babá', 'Locais especializados em cuidados infantis', 'url_servicos_baba_pt.jpg', 1, 36, 'br'),
(UUID(), NOW(), NOW(), 'Servicios de Niñera', 'Locales especializados en cuidado infantil', 'url_servicos_baba_es.jpg', 1, 36, 'es'),

(UUID(), NOW(), NOW(), 'Serviços para Idosos', 'Locais especializados em cuidados para idosos', 'url_servicos_idosos_pt.jpg', 1, 37, 'br'),
(UUID(), NOW(), NOW(), 'Servicios para Ancianos', 'Locales especializados en cuidado de ancianos', 'url_servicos_idosos_es.jpg', 1, 37, 'es');




SELECT * FROM agendamento.tiposervico;