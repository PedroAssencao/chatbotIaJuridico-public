use master
go
create database ChatbotIaJuridico
go
use ChatbotIaJuridico
go
create table advogado (
    adv_id int identity(1,1) primary key,
    adv_senha varchar(255) not null,
    adv_waid varchar(255) not null,
	adv_nome varchar(255) not null,
	adv_cpf varchar(14) not null
)
create table cliente (
    cli_id int identity(1,1) primary key,
	cli_nome varchar(255),
	cli_dataCriacao datetime default GETDATE(),
	cli_dataModificacao datetime default GETDATE(),
	cli_cpf varchar(14) not null,
	adv_id int FOREIGN KEY REFERENCES advogado(adv_id) not null
)
go
create table preProcesso(
	pProc_id int identity(1,1) primary key,
	pProc_nome varchar(255) not null,
	pProc_descricao varchar(255),
	pProc_dataCriacao datetime default GETDATE(),
	pProc_dataModificacao datetime default GETDATE(),
	pProc_estado int,
	pProc_tipo int not null,
	adv_id int FOREIGN KEY REFERENCES advogado(adv_id) not null,
	cli_id int FOREIGN KEY REFERENCES cliente(cli_id) not null
)
go
create table peticao(
	pet_id int identity(1,1) primary key,
	pet_caminho varchar(500) not null,
	pet_descricao varchar(255),
	pet_dataCriacao datetime default GETDATE(),
	pet_dataModificacao datetime default GETDATE(),
	pet_tipo int not null,
	adv_id int FOREIGN KEY REFERENCES advogado(adv_id) not null,
)
go
create table chat (
    cha_id int identity(1,1) primary key,
	cha_estado int not null,
    adv_id int FOREIGN KEY REFERENCES advogado(adv_id) not null
)
go
create table insumo (
    ins_id int identity(1,1) primary key,
    ins_data DATETIME DEFAULT GETDATE(),
	ins_caminho varchar(max),
    ins_descricao varchar(max),
	ins_transcricao varchar(max),
	ins_Waid varchar(max),
    ins_tipo int not null,
	adv_id int FOREIGN KEY REFERENCES advogado(adv_id) not null,
	pProc_id int FOREIGN KEY REFERENCES preProcesso(pProc_id) not null,
	cha_id int FOREIGN KEY REFERENCES chat(cha_id) not null
)

create table preInsumo (
    pIns_id int identity(1,1) primary key,
    pIns_data DATETIME DEFAULT GETDATE(),
	pIns_caminho varchar(max),
    pIns_descricao varchar(max),
	pIns_Waid varchar(max),
	pIns_dataModificacao datetime default GETDATE(),
    pIns_tipo int not null,
	adv_id int FOREIGN KEY REFERENCES advogado(adv_id) not null,
	cha_id int FOREIGN KEY REFERENCES chat(cha_id) not null
)
go
create table menus (
    men_id int identity(1,1) primary key,
    men_header varchar(255),
    men_footer varchar(255),
    men_body varchar(255) not null,
    men_tipo int not null,
    men_title varchar(255) not null,
)
go
create table options (
    opt_id int identity(1,1) primary key,
    opt_data DATETIME DEFAULT GETDATE(),
    opt_descricao varchar(500),
    opt_finalizar bit DEFAULT 0,
    opt_resposta varchar(500),
    opt_tipo int not null,
    opt_title varchar(24),
    men_id int FOREIGN KEY REFERENCES menus(men_id) not null,
)
go
create table configuracaoGeral(
	confg_id int identity(1,1) primary key,
	conf_descricao varchar (255) not null,
	confg_ativa bit DEFAULT 1,
	confg_valor varchar(500)
)
go
create table prompt(
	promp_id int identity(1,1) primary key,
	promp_descricao varchar (255) not null,
	promp_ativa bit DEFAULT 1,
	promp_valor varchar(max)
)
go

INSERT INTO advogado (adv_senha, adv_waid, adv_nome, adv_cpf)
VALUES ('senha123', '557988132044', 'Pedro M.R. Assenção', '76489067515');

INSERT INTO advogado (adv_senha, adv_waid, adv_nome, adv_cpf)
VALUES ('senha123', '557998215861', 'Reginaldo R. Santana', '76489067419');

INSERT INTO advogado (adv_senha, adv_waid, adv_nome, adv_cpf)
VALUES ('senha123', '557981327506', 'Luis Viana', '76479067419');

INSERT INTO menus (men_header, men_footer, men_body, men_tipo, men_title)
VALUES ('', '', 'Você deseja enviar esse insumo para qual cpf?', 1, 'Menu de Encaminhamento Cpf');

INSERT INTO options (opt_descricao, opt_finalizar, opt_resposta, opt_tipo, opt_title, men_id)
VALUES ('Inserir um cpf para busca.', 0, 'Digite o cpf abaixo', 2, 'Outro', 1);
INSERT INTO options (opt_descricao, opt_finalizar, opt_resposta, opt_tipo, opt_title, men_id)
VALUES ('Inserir um novo cpf.', 0, 'Digite o cpf abaixo', 5, 'Cadastrar novo cpf', 1);

INSERT INTO menus (men_header, men_footer, men_body, men_tipo, men_title)
VALUES ('', '', 'Você Deseja enviar esse insumo para qual pré processo?', 2, 'Menu de Encaminhamento Processo');

INSERT INTO options (opt_descricao, opt_finalizar, opt_resposta, opt_tipo, opt_title, men_id)
VALUES ('Inserir o codigo do pre processo', 0, 'Digite o codigo do Pre-Processo', 4, 'Outro', 2);
INSERT INTO options (opt_descricao, opt_finalizar, opt_resposta, opt_tipo, opt_title, men_id)
VALUES ('Criar um novo pre processo', 0, 'Pre processo cadastrado', 3, 'Criar novo pre processo', 2);

INSERT INTO menus (men_header, men_footer, men_body, men_tipo, men_title)
VALUES ('', '', 'Oque você gostaria de fazer?', 3, 'Menu de comandos');

INSERT INTO options (opt_descricao, opt_finalizar, opt_resposta, opt_tipo, opt_title, men_id)
VALUES ('Escolher um pre-processo para gerar petição', 0, 'Digite o codigo do Pre-Processo', 8, 'Gerar Petição', 3);

INSERT INTO menus (men_header, men_footer, men_body, men_tipo, men_title)
VALUES ('', '', 'Oque você gostaria de fazer?', 4, 'Menu de Interaçao com IA');

INSERT INTO options (opt_descricao, opt_finalizar, opt_resposta, opt_tipo, opt_title, men_id)
VALUES ('Continuar a gerar petição sem cadastrar mais insumos.', 0, '', 9, 'Continuar', 4);
INSERT INTO options (opt_descricao, opt_finalizar, opt_resposta, opt_tipo, opt_title, men_id)
VALUES ('Inserir um insumo que tera destaque na geração da petição', 0, '', 10, 'Visão do advogado', 4);
INSERT INTO options (opt_descricao, opt_finalizar, opt_resposta, opt_tipo, opt_title, men_id)
VALUES ('Cançelar a geração da petição', 0, '', 11, 'Cancelar', 4);


INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('gptKey', 1, '');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('metaApiKey', 1, '');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('metaMidiaEndpoint', 1, 'https://graph.facebook.com/v20.0/{{midia_url}}');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('metaMessageEndpoint', 1, 'https://graph.facebook.com/v20.0/{{phone_number_id}}/messages');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('testPhonenNumberId', 1, '');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('prodPhonenNumberId', 1, '');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textClientNotFound', 1, 'Você não tem nenhum cliente cadastrado, por favor insira o cpf do cliente abaixo');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textAdvogadoNotFound', 1, 'Você não tem cadastro no sistema, por favor entre em contatos com os adms para resolver problemas com login: {{numero_contanto}}');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textClientCadastrado', 1, 'Cliente Cadastrado. Pre processo criado!');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textSolicitandoNomeCliente', 1, 'Por favor digite o nome do cliente.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textSolicitarNomePreProcesso', 1, 'Por favor digite o nome do Pre-Processo que sera gerado para seu cliente.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textSolicitarDescricaoPreProcesso', 1, 'Por favor digite a descrição do Pre-Processo.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textSucessoCadastroPreProcessoEConfirmacaoDeEnvio', 1, 'Cadastro Inicial de Cliente Concluido! O modo de envio de arquivo esta ativo');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textErrorAoSolicitarCpf', 1, 'Ocorreu o error ao cadastrar o insumo como cpf do cliente, lembrese de mandar o conteudo apenas como texto, sem pontuação e em que não seja em formato de documento.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textErrorAoSolicitarNome', 1, 'Ocorreu o error ao cadastrar o insumo como nome do cliente, lembrese de mandar o conteudo apenas como texto, sem pontuação e em que não seja em formato de documento.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textErrorAoSolicitarNomePreProcesso', 1, 'Ocorreu o error ao cadastrar o insumo como nome do pre processo, lembrese de mandar o conteudo apenas como texto, sem pontuação e em que não seja em formato de documento.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textErrorAoSolicitarDescricaoPreProcesso', 1, 'Ocorreu o error ao cadastrar o insumo como descrição do pre processo, lembrese de mandar o conteudo apenas como texto, sem pontuação e em que não seja em formato de documento.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textCadastroCliente', 1, 'Digite o cpf do cliente abaixo');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textInsumoCadastradoComSucesso', 1, 'Insumo cadastrado com sucesso!!! Modo de envio ativado.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textBuscaClientePorCpfOuNome', 1, 'Digite abaixo ou o nome ou cpf do cliente.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textBuscaPreProcessoPorCodigoOuNome', 1, 'Digite abaixo ou o nome ou codigo do pre processo.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textPreProcessoCadastradoEInsumoInserido', 1, 'Pre-processo cadastrado e insumo inserido.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textGerancoPeticao', 1, 'Aguarde estamos gerando a petição...');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textErrorAcaoEnquantoGeraPeticao', 1, 'Uma petição esta sendo gerada. não e possivel executar outra ação no momento');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('gptCompletionsEndpoint', 1, 'https://api.openai.com/v1/chat/completions');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textErrorAoGerarPeticao', 1, 'Ocorreu um error ao tentar gerar a petição, por favor tente novamente.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textCancelarGeracaoPetição', 1, 'Geração Cancelada! Modo de Envio Ativado.');
INSERT INTO configuracaoGeral (conf_descricao, confg_ativa, confg_valor)
VALUES ('textPedidoParaContinuarOEnvioDeInsumo', 1, 'Envie seu insumo!');

insert into prompt (promp_descricao, promp_ativa, promp_valor) values ('promptParaGeracaoDePeticaoV1',1,'
Você é um assistente jurídico especializado em Direito Civil. Sua tarefa é elaborar uma Petição de Exibição de Documentos para ingresso em juízo, em favor do meu cliente.

### Instruções Gerais:
1. Estruture e formate a petição de acordo com as normas processuais civis brasileiras, garantindo que todos os elementos essenciais estejam presentes (ex.: qualificação das partes, fatos, fundamentação legal e pedidos).
2. Extraia os fatos, fundamentos legais e pedidos exclusivamente a partir das informações fornecidas no comando desta requisição (transcrições, documentos ou instruções adicionais).

###Modelo de Exemplo para ser utilizado APENAS COMO EXEMPLO VOCE NAO DEVE USAR NENHUMA DESSAS INFORMAÇOES PARA GERAR O JSON ELE VAI ESTAR ENTRE COLCHETES 
[{0}]

### Observações:
- Baseie-se apenas nas informações fornecidas no comando para preencher a petição. Não gere conteúdo fictício.
- Se não houver informações suficientes no comando, indique ''[não informado]'' nos campos correspondentes.
- Retorne a resposta exclusivamente no seguinte formato JSON:

### Formato de Retorno:
Retorne a resposta exclusivamente no seguinte formato JSON, preenchendo todos os campos com base nas transcrições fornecidas no comando:
{{
  ""PeticaoTipo"": ""{1}"",
  ""Parte"": {{
    ""Nome"": ""[Nome da parte]"",
    ""CPF"": ""[CPF da parte]"",
    ""Endereco"": ""[Endereço da parte]""
  }},
  ""Reu"": {{
    ""Nome"": ""[Nome do réu]"",
    ""CPF/CNPJ"": ""[CPF/CNPJ do réu]"",
    ""Endereco"": ""[Endereço do réu]""
  }},
  ""Fatos"": [
    ""[Descrição dos fatos relevantes extraídos do comando.] (retorne pelo menos uma lista de 4 items)""
  ],
  ""DoDireito"": [
    ""[Fundamentação legal e jurisprudencial baseada no comando. Inclua tambem as leis e clausulas para maior validade da argumentação] (retorne pelo menos uma lista de 4 items)""
  ],
  ""Pedidos"": [
    ""[Lista de pedidos extraídos do comando ou típicos para este tipo de petição.] (retorne pelo menos uma lista de 4 items)""
  ]
}}

### Observações:
- Use apenas as informações das transcrições fornecidas no comando para preencher os campos ''Fatos'' e ''Do Direito''.
- Não gere conteúdo fictício; baseie-se exclusivamente no que for transcrito.
- Retorne apenas o JSON, sem texto adicional.
- Se nos insumos não tiver informações suficientes para preencher todos os campos, deixe os campos com o texto [não informado], mais retorne o json.
- TODAS AS VEZES RETORNE O JSON MESMO QUE SEJA COM OS CAMPOS VAZIOS,
- RETORNE APENAS O JSON SEM MAIS NEM MENOS, NÃO QUERO NEM UM [```json] OU ````` APENAS O JSON E SO O JSON.
- VOCE ESTA EXTRITAMENTE PROIBIDO DE RETORNAR QUALQUER COISA QUE NÃO SEJA UM JSON QUE ESTA NO FORMATO  ADEQUADO E VOCE SO VAI RETORNAR ESSE JSON MAIS NADA SEM NENHUM CARACTER ENTRE ELES NEM NADA.
- VOCE ESTA EXTRITAMENTE PROIBIDO DE USAR QUALQUER INFORMAÇÃO QUE FOI DADO NO MODELO DE EXEMPLO PARA GERAR A RESPOSTA, VOCE APENAS IRA GERAR A RESPOSTA COM INSUMOS QUE FORAM RECEBIDOS NO COMANDO.
- VOCE DEVE SEGUIR A RISCA TODAS AS REGRAS QUE ESTAO AQUI E PELO COMANDO EXTRITAMENTE.
- SE A INFORMAÇÃO NAO FOI PASSADA NO COMANDO VOCE NÃO COLOCA NA GERACAO DA RESPOSTA NÃO QUERO NADA DOQUE FOI DADO DE EXEMPLO NO MODELO NA RESPOSTA REPITO NADA, SE NAO TIVER O CONTEUDO PARA GERAR A RESPOSTA APENAS COLOQUE NÃO INFORMADO NAO PEGUE DO MODELO DE EXEMPLO.
- RETORNE EM UM FORMATO JSON VALIDO ESSA REGRA AQUI TAMBEM E IMUTAVEL, RETORNE SEMPRE UM FORMATO JSON VALIDO. 
')

insert into prompt (promp_descricao, promp_ativa, promp_valor) values ('promptParaGeracaoDePeticaoV2',1,'
Você é um assistente jurídico especializado em Direito Civil. Sua tarefa é elaborar uma Petição de Exibição de Documentos para ingresso em juízo, em favor do meu cliente.

### Instruções Gerais:
1. Estruture e formate a petição de acordo com as normas processuais civis brasileiras, garantindo que todos os elementos essenciais estejam presentes (ex.: qualificação das partes, fatos, fundamentação legal e pedidos).
2. Extraia os fatos, fundamentos legais e pedidos exclusivamente a partir das informações fornecidas no comando desta requisição (transcrições, documentos ou instruções adicionais).

###Modelo de Exemplo para ser utilizado APENAS COMO EXEMPLO VOCE NAO DEVE USAR NENHUMA DESSAS INFORMAÇOES PARA GERAR O JSON ELE VAI ESTAR ENTRE COLCHETES 
[{0}]

### Observações:
- Baseie-se apenas nas informações fornecidas no comando para preencher a petição. Não gere conteúdo fictício.
- Se não houver informações suficientes no comando, indique ''[não informado]'' nos campos correspondentes.
- Retorne a resposta exclusivamente no seguinte formato JSON:

### Formato de Retorno:
Retorne a resposta exclusivamente no seguinte formato JSON, preenchendo todos os campos com base nas transcrições fornecidas no comando:
{{
  ""PeticaoTipo"": ""{1}"",
  ""Parte"": {{
    ""Nome"": ""[Nome da parte]"",
    ""CPF"": ""[CPF da parte]"",
    ""Endereco"": ""[Endereço da parte]""
  }},
  ""Reu"": {{
    ""Nome"": ""[Nome do réu]"",
    ""CPF/CNPJ"": ""[CPF/CNPJ do réu]"",
    ""Endereco"": ""[Endereço do réu]""
  }},
  ""Fatos"": [
    ""[Descrição dos fatos relevantes extraídos do comando.] (retorne pelo menos uma lista de 4 items)""
  ],
  ""DoDireito"": [
    ""[Fundamentação legal e jurisprudencial baseada no comando. Inclua tambem as leis e clausulas para maior validade da argumentação] (retorne pelo menos uma lista de 4 items)""
  ],
  ""Pedidos"": [
    ""[Lista de pedidos extraídos do comando ou típicos para este tipo de petição.] (retorne pelo menos uma lista de 4 items)""
  ]
  ""JurisPrudencia"": [
    ""[Lista de jurisprudencia extraídos do comando ou típicos para este tipo de petição.] (retorne pelo menos uma lista de 4 items)""
  ]
}}

### Observações:
- Use apenas as informações das transcrições fornecidas no comando para preencher os campos ''Fatos'' e ''Do Direito''.
- Não gere conteúdo fictício; baseie-se exclusivamente no que for transcrito.
- Retorne apenas o JSON, sem texto adicional.
- Se nos insumos não tiver informações suficientes para preencher todos os campos, deixe os campos com o texto [não informado], mais retorne o json.
- TODAS AS VEZES RETORNE O JSON MESMO QUE SEJA COM OS CAMPOS VAZIOS,
- RETORNE APENAS O JSON SEM MAIS NEM MENOS, NÃO QUERO NEM UM [```json] OU ````` APENAS O JSON E SO O JSON.
- VOCE ESTA EXTRITAMENTE PROIBIDO DE RETORNAR QUALQUER COISA QUE NÃO SEJA UM JSON QUE ESTA NO FORMATO  ADEQUADO E VOCE SO VAI RETORNAR ESSE JSON MAIS NADA SEM NENHUM CARACTER ENTRE ELES NEM NADA.
- VOCE ESTA EXTRITAMENTE PROIBIDO DE USAR QUALQUER INFORMAÇÃO QUE FOI DADO NO MODELO DE EXEMPLO PARA GERAR A RESPOSTA, VOCE APENAS IRA GERAR A RESPOSTA COM INSUMOS QUE FORAM RECEBIDOS NO COMANDO.
- VOCE DEVE SEGUIR A RISCA TODAS AS REGRAS QUE ESTAO AQUI E PELO COMANDO EXTRITAMENTE.
- SE A INFORMAÇÃO NAO FOI PASSADA NO COMANDO VOCE NÃO COLOCA NA GERACAO DA RESPOSTA NÃO QUERO NADA DOQUE FOI DADO DE EXEMPLO NO MODELO NA RESPOSTA REPITO NADA, SE NAO TIVER O CONTEUDO PARA GERAR A RESPOSTA APENAS COLOQUE NÃO INFORMADO NAO PEGUE DO MODELO DE EXEMPLO.
- RETORNE EM UM FORMATO JSON VALIDO ESSA REGRA AQUI TAMBEM E IMUTAVEL, RETORNE SEMPRE UM FORMATO JSON VALIDO. 
')

insert into prompt (promp_descricao, promp_ativa, promp_valor) values ('prompParaGeraçãoDoStorylineV1',1,'
você e um assistente juridico, que faz uso dos fatos informados no comando do usuario, dando sempre peferencia para os fatos do advogado. Para gerar um story line com o caso, voce divide esse texto em duas sessoes. Uma delas e a sessão do story line. E a segunda sessão e a jurisprudencia que pode ser usada nesse caso. Para a jurisprudencia voce faz uma sitação DIRETA a uma jurisprudencia real. E inclusive coloca dados referentes a jurisprudencia correta. DE FORMA ALGUMA INVENTE DADOS. se não tiver uma fonte confiavel na internet apenas coloque que a jurisprudencia ou resumo não foi possivel/encontrada para aquele caso, coloque tudo que voce não achar como "[não informado]"')



insert into prompt (promp_descricao, promp_ativa, promp_valor) values ('inforsArquivosBase',1,'
 apartir daqui oque tiver em colchetes e o conteudo do modelo use como exemplo E APENAS COMO EXEMPLO NÃO EXTRAIA NENHUMA INFORMAÇÃO DESSE EXEMPLO PARA SUA RESPOSTA. USE APENAS OS INSUMOS QUE FOI MANDADO NO COMANDO, NAO USE NENHUMA DESSAS INFORMAÇÕES PARA GERAR A RESPOSTA APENAS USE DE EXEMPLAR:
            [
            EXCELENTÍSSIMO SENHOR DOUTOR JUIZ DE DIREITO DA VARA CIVEL DA COMARCA DE ARACAJU, ESTADO DE SERGIPE.  

    

REGINALDO REIS DE SANTANA, brasileiro, maior, capaz, casado, professor, inscrito no CPF sob o nº 017.027.685-62, residente e domiciliado a Rua Francisco de Assis Delmondes Pereira Freitas, nº200, condomínio Ecoville Park, bloco cidade, apto 203, bairro Ponto Novo, Aracaju/SE, vem à honrosa presença de Vossa Excelência propor:  

  

AÇÃO DE EXIBIÇÃO DE DOCUMENTOS  

 em face de CONDOMÍNIO ECOVILLE PARK I, inscrito no CNPJ nº 21.037.672/0001-41, com sede na rua Francisco de Assis Delmondes Pereira Freitas, nº 200, bairro Ponto Novo, Aracaju/SE, CEP 49097-710; , telefone administrativo (79) 99657-9016, CONDOMÍNIO ECOVILLE PARK II, inscrito no CNPJ nº 21.019.478/0001-33, com sede na rua Francisco de Assis Delmondes Pereira Freitas, nº 170, bairro Ponto Novo, Aracaju/SE, CEP 49097- 710 e em face de ANTÔNIO JOSE LUIZ BOTELHO, CPF 475.843.867-68, telefone (79)99802-9444, residente na rua Francisco de Assis Delmondes Pereira Freitas, nº 170, bairro Ponto Novo, Aracaju/SE, CEP 49097- 710, Bloco 03, apartamento 203. 

 

I – DA REALIDADE DOS FATOS.   

O Requerente é condômino do Condomínio Ecoville Park com seus pagamentos em dia, o qual possui o dever de transparência na gestão administrativa e financeira, garantindo a todos os condôminos o direito de acesso às informações pertinentes, como também, já foi membro de comissão eleitoral e conselho fiscal. 

Em 24 de outubro de 2024, o Requerente solicitou ao síndico Antônio Botelho, por meio de canal oficial do condomínio (app condomob)  (anexo  – 01_Pedido_ListaPresencaEleicoes_24102024), o envio da lista de presença da última eleição condominial, documento essencial para o acompanhamento, fiscalizar como morador os acontecimentos ocorridos no processo eleitoral, se os procedimentos seguiram os ritos regimentais. 

 

No pedido do dia 24/10/2024 o requerente ainda citou o artigo 15º do regimento para que o síndico pode-se fazer a liberação, ou permitir que o requerente fosse até a administração examinar os livros. 

 

Segue o artigo na integra, no caso Inciso III, do artigo 15º do regimento: 

 

Ainda tentando mais uma vez obter acesso ao documento o requerente fez nova solicitação no dia 04/11/2024 (anexo 02_Pedido_Lista_24102024.pdf) e ficou surpreso com a resposta da gestão orientando o requerente para  que fosse até o cartório obter tais informações. Na resposta (conforme documentado) o síndico atual, ANTONIO BOTELHO, informou que estava seguindo orientação do corpo jurídico do condomínio e que dessa forma não poderia disponibilizar. 

Interface gráfica do usuário, Texto

O conteúdo gerado por IA pode estar incorreto. 

No dia 09/01/2025 o requerente solicitou também a lista de presença da assembleia de 29 de outubro de 2024, uma vez que na ata teve pauta com votações, mas não existe em nenhuma informação do quantitativo de pessoas estavam presentes. Tal informação é essencial para sabermos e votações que precisam de 2/3 de quórum presente, se foi seguido o rito regimental correto. Entretanto, até a data presente o condômino não obteve NENHUM retorno no aplicativo oficial do condomínio CONDOMOB, ou por outros meios. 

 

Vale ressaltar ainda, que o requerente sempre que pediu a lista de presença as gestões anteriores, sempre teve sucesso, como o pedido enviado em 12/03/2024 da assembleia 16 de janeiro de 2024, onde a síndica da época enviou por e-mail no dia 20/03/2024.  

 

O que causa mais perplexidade é o fato que o escritório jurídico da época é o mesmo que segundo o síndico ANTONIO BOTELHO orientou para não ceder o documento.  

Ressalte-se que tal justificativa não transfere ao referido órgão externo (Corpo Jurídico) o poder decisório, pois sua função é MERAMENTE orientar o condomínio, não possuindo qualquer atribuição para indeferir o direito dos condôminos de acesso às informações. A responsabilidade exclusiva de gerir e disponibilizar os documentos é do síndico, conforme preceitua o Regimento Interno. 

Já se passaram mais de 40 dias do último pedido de acesso a lista de presença da assembleia de 29 de outubro de 2024, mas que o requerente não obteve nenhum retorno. 

Declare-se ainda, que o requerente é um condômino ativo em sempre esteve preocupado com o bem coletivo, onde desde que passou a residir vem atuando de forma ativa para que todos os moradores e gestores sigam o regimento a fim de evitarmos problemas, como no passado, onde um gestor usou R$ 5.000,00 (via PIX) do condomínio para entrar com ação contra o próprio condomínio. O condomínio hoje desponta com saldo em caixa de mais de R$ 500.000,00 (quinhentos mil reais), o que poderia ser um valor maior, se os gestores do passado tivessem gerido o condomínio com maior eficiência. 

 

II – DO DIREITO 

Nos termos do Regimento Interno, todos os condôminos têm direito a informações claras e transparentes sobre a administração do condomínio, garantindo a fiscalização dos atos administrativos e eleitorais. 

Contemplemos inicialmente o artigo 5º do regimento: 

Art. 5º - é dever do síndico, do subsíndico, dos conselho fiscal, dos empregados do condomínio e dos condôminos, zelar pela observância das normas gerais e especificas, bem como pela segurança, convivência harmoniosa e pelo patrimônio comum do condomínio. 

Ao negar o acesso aos documentos, mesmo que somente para examinar o requerente ficou impedido de fiscalizar o processo eleitoral e outras votações, pois jamais poderíamos afirmar que o requerente cumpriu seu dever de zelar pela observância das normas gerais e especificas se ele foi IMPEDIDO.  Aqui não se faz qualquer acusação antecipada de que houve erros no processo eleitoral ou em qualquer assembleia, o que está sendo colocado em contexto é  a negação de o condômino exercer seu direito e dever zelar pela observância das normas, que é um dever de todos, inclusive do SÍNDICO. 

Também, contamos com o artigo 15º, inciso III do regimento, que se trata dos direitos dos condôminos, além dos previstos no código civil em seu artigo 1.335: 

Art. 15º, Inciso III. Examinar os livros, arquivos da administração, mediante solicitação prévia ao síndico ou a quem por este autorizado 

O requerente pediu inicialmente o envio de uma cópia, uma prática já comum em outras gestões (anexado), não obtendo retorno positivo solicitou para averiguar a lista presencialmente “in loco” na sala de administração, o que teve outra NEGATIVA. 

Interface gráfica do usuário, Texto, Aplicativo, Email

O conteúdo gerado por IA pode estar incorreto. 

É inegável que as provas por si só deixam claro que o requerente tentou várias vezes acesso das listas de presenças, mas só obteve negativas. O requerente cumpriu o rito mínimo de solicitação prévia, mas não fora atendido.  

Podemos ainda sermos contemplados por jurisprudência já julgada no TRIBUNAL DE JUSTIÇA DO ESTADO DE SERGIPE no processo de número 201210800686 (2012), vejamos: 

Assim, não há óbice legal nem convencional à exibição dos documentos, pois versam sobre questões relativas à regularidade da administração do Condomínio e que, consequentemente, são da esfera de interesse de todo e qualquer condômino. Ex positis, diante das razões supra alinhavadas, JULGOPROCEDENTE o pedido contido na AÇÃO CAUTELAR DE EXIBIÇÃO DE DOCUMENTO, ajuizada por GONÇALO SOBRAL DA SILVEIRA JÚNIOR e JOSÉ FRANCISCO DA CUNHA NETO em face de ANTÔNIO LEMOS e CONDOMÍNIO RESIDENCIAL EDIFÍCIO JOSÉ ANDRADE NETO, para determinar que a parte requerida apresente/exiba aos autores cópia das Atas das Assembleias Gerais ordinárias realizadas para aprovação da Convenção do condomínio; cópia de documento no qual conste a lista de todos os condôminos eleitores (Corpo de Eleitores); cópia de documento no qual conste quais eleitores compareceram e votaram na Assembleia Geral realizada no dia 26 de abril de 2012, e quais eleitores não compareceram, mas fizeram-se representar por procuração e, ainda, quais eleitores não compareceram e nem exerceram seu direito de voto; cópia da procurações dos eleitores que fizeram-se representar; e cópia dos balancetes mensais desde 01/09/2008.d 

A doutrina e a jurisprudência reconhecem a legitimidade dos condôminos para requerer judicialmente o acesso aos documentos administrativos, de forma a assegurar a transparência e a correta administração do condomínio. 

 

III - DOS PEDIDOS  

a) concessão para determinar que os Requeridos exibam, no prazo que Vossa Excelência fixar, as listas de presenças da última eleição condominial de 20/08/2024 (eleição), da assembleia de 29/10/2024 e da assembleia de 08/01/2025. 

b) A intimação dos Requeridos para Vossa Excelência estando de acordo ao acesso a lista, permitir fotografar, tirar cópia sem gerar custos para o condomínio (podem serem usadas em futuras ações, caso haja necessidade). 

c) Requer, ainda, a fixação de multa diária (astreintes), no valor que seja definido por Vossa Excelência, em caso de descumprimento da ordem judicial de exibição dos documentos, nos termos do artigo 537 do CPC, para garantir a efetividade da decisão."" 

d) Ao final, seja condenando os Requeridos ao pagamento das custas processuais e honorários advocatícios, a serem fixados conforme os ditames do art. 20 do CPC 

Dá-se à causa o valor de R$ 1.000,00 (um mil e quinhentos reais) para efeitos meramente fiscais. Nestes termos, pede deferimento. 

 

 

 

Nestes Termos, 

Pede Deferimento. 

Aracaju/SE, 28 de fevereiro de 2025 

Luis Paulo Viana Nunes  

Advogado - OAB/SE SE 13.616 
]
')