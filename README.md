# ChatbotIaJuridico ⚖️ - Assistente Jurídico Inteligente

O **ChatbotIaJuridico** é uma solução de backend desenvolvida em **.NET 8.0** projetada para automatizar e auxiliar escritórios de advocacia. O sistema atua como um orquestrador de conversas via **WhatsApp (Meta API)**, utilizando **Inteligência Artificial (OpenAI)** para processar insumos multimídia (áudio, vídeo, imagens, documentos), transcrever conteúdos e gerar automaticamente peças jurídicas (Petições) em formatos PDF e DOCX.

---

## 🛠️ Instalação

Siga os passos abaixo para configurar e rodar o projeto localmente.

### Pré-requisitos

Certifique-se de ter instalado:

* **SDK do .NET 8.0**
* **SQL Server**

### 1. Configuração do Banco de Dados

1.  Crie um novo banco de dados no seu SQL Server (sugestão: `ChatbotIaJuridico`).
2.  Execute o script SQL localizado em `Scripts/ScriptAtualizado_15_03_2025_.sql`. Este script cria as tabelas necessárias (`advogado`, `cliente`, `chat`, `insumo`, `peticao`, etc.) e insere dados iniciais de configuração e prompts.

### 2. Configuração do Backend (`ChatbotIaJuridico.API`)

1.  Navegue até a pasta `Src/ChatbotIaJuridico.Solution/ChatbotIaJuridico.API`.
2.  Renomeie o arquivo `appsettings.example.json` para `appsettings.Development.json` (ou edite o existente).
3.  Configure a **ConnectionString** (`Chinook`) apontando para o seu banco de dados SQL Server.
4.  **Nota sobre Chaves de API**: As chaves da **OpenAI** (`gptKey`) e da **Meta/WhatsApp** (`metaApiKey`), bem como os endpoints, são configurados diretamente no banco de dados na tabela `configuracaoGeral` pelo script inicial, mas verifique se precisam de atualização.

### 3. Execução

1.  Na raiz do projeto API, execute o comando:
    ```bash
    dotnet run
    ```
2.  A API estará acessível (por padrão) em `http://localhost:5021` ou `https://localhost:7094`.
3.  A documentação Swagger pode ser acessada em `/swagger` para testar os endpoints.

---

## 🚀 Uso

O sistema funciona principalmente através de webhooks e processamento em segundo plano.

### Funcionalidades Principais

* **Webhook WhatsApp (`/api/v1/Meta/hook`)**: Ponto de entrada para mensagens enviadas por advogados e clientes. O sistema identifica o tipo de mensagem (texto, áudio, documento) e processa o contexto.
* **Gestão de Estado (`EChatEstado`)**: O bot gerencia o fluxo da conversa através de estados definidos (ex: `AguardandoCpf`, `GerandoPeticao`, `AguardandoInsumos`), garantindo que a IA solicite as informações corretas no momento certo.
* **Processamento de Insumos**:
    * **Transcrição de Áudio/Vídeo**: Utiliza o modelo **Whisper** da OpenAI para transcrever áudios enviados via WhatsApp.
    * **Leitura de Documentos/Imagens**: Extrai texto de PDFs, DOCX e imagens para compor os fatos do processo.
* **Geração de Petição**: Com base nos insumos coletados, o sistema utiliza o **GPT-4o** para redigir a petição inicial e a gera fisicamente em arquivos **.pdf** (via iTextSharp) e **.docx** (via OpenXML) na pasta `/arquivos`.

---

## 🎨 Estilo de Codificação

O projeto segue uma **Arquitetura em Camadas (N-Layer)**, promovendo a separação de responsabilidades e facilitando a manutenção:

### Estrutura da Solução

* **ChatbotIaJuridico.Domain**: Contém as entidades do banco de dados (ex: `Advogado`, `Peticao`, `Insumo`), Enums (`EPeticaoTipo`, `EChatEstado`) e modelos de DTO para as APIs da Meta e OpenAI.
* **ChatbotIaJuridico.Services**: Camada de regras de negócio. Gerencia os fluxos de cadastro, a lógica de orquestração do chat (`ChatServices`) e a comunicação entre os repositórios e os controladores.
* **ChatbotIaJuridico.Infra**: Responsável pela persistência de dados utilizando **Entity Framework Core**. Contém o `DbContext` e os Repositórios Genéricos e Específicos.
* **ChatbotIaJuridico.Infra.OpenAi / Meta / Storage**: Projetos de infraestrutura específicos para integrações externas, isolando a lógica de consumo de APIs de terceiros e manipulação de arquivos.
* **ChatbotIaJuridico.API**: Camada de apresentação (REST API), contendo os Controllers, configurações de injeção de dependência (`Extensions`) e configuração do Swagger.
