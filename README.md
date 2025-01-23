# NutriPro 🥗

**NutriPro** é um micro-SaaS inovador que utiliza inteligência artificial para criar dietas personalizadas com base nas preferências e objetivos dos usuários. Desenvolvido em **ASP.NET MVC** e **.NET 8**, este projeto aproveita a poderosa API da **OpenAI (GPT-4)** para fornecer recomendações nutricionais inteligentes e sob medida. Além disso, o sistema possui um **link de pagamento** gerado na plataforma **Kiwify** para facilitar o processo de pagamento.

---

## 🚀 Funcionalidades Principais

- **Criação de Dietas Personalizadas**: O usuário informa seus objetivos e preferências alimentares, e o sistema gera uma dieta adaptada às suas necessidades.
- **Inteligência Artificial com GPT-4**: Geração de recomendações nutricionais baseadas em dados fornecidos pelos usuários, utilizando a API da OpenAI.
- **Interface Amigável**: Uma aplicação moderna e intuitiva desenvolvida com **ASP.NET MVC**.
- **Pagamentos Simplificados**: Um link de pagamento gerado na **Kiwify** para facilitar o pagamento.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem e Frameworks**:
  - ASP.NET MVC
  - .NET 8
- **Integrações**:
  - OpenAI API (GPT-4)
- **Ferramentas e Outras Dependências**:
  - Git/GitHub para controle de versão
  - Visual Studio como ambiente de desenvolvimento

---

## 📖 Como Funciona

1. **Entrada de Dados** 📊
   - O usuário fornece informações como:
     - Objetivos (ex: perder peso, ganhar massa muscular)
     - Preferências alimentares (ex: restrições, alergias, alimentos favoritos)

2. **Geração da Dieta** 🍽️
   - A inteligência artificial analisa os dados e cria uma dieta personalizada.

3. **Pagamento** 💳
   - O pagamento é realizado através de um link gerado na plataforma Kiwify.

4. **Acesso à Dieta** 📱
   - O usuário pode visualizar sua dieta diretamente pela plataforma.

---

## 🌟 Diferenciais

- **Personalização Completa**: Nenhuma dieta é igual; cada uma é ajustada ao perfil do usuário.
- **Velocidade e Precisão**: A utilização do GPT-4 garante respostas rápidas e recomendações confiáveis.
- **Facilidade de Uso**: Interface projetada para oferecer uma experiência agradável e intuitiva.
- **Pagamentos Acessíveis**: Link de pagamento direto pela Kiwify.

---

## 💻 Como Executar Localmente

1. **Clone o Repositório**:
   ```bash
   git clone https://github.com/ericposser/NutriPro.git
   ```

2. **Acesse o Diretório do Projeto**:
   ```bash
   cd NutriPro
   ```

3. **Configure a API da OpenAI**:
   - Adicione suas credenciais da OpenAI no arquivo `appsettings.json`:
     ```json
     "OpenAI": {
       "ApiKey": "sua-chave-aqui"
     }
     ```

4. **Configure o Banco de Dados**:
   - Atualize a string de conexão no arquivo `appsettings.json`.

5. **Execute o Projeto**:
   ```bash
   dotnet run
   ```

6. **Acesse no Navegador**:
   - Abra [http://localhost:5000](http://localhost:5000) no seu navegador.

---

## 📦 Estrutura do Projeto

- `Controllers/`: Controladores da aplicação.
- `Models/`: Modelos utilizados no sistema.
- `Views/`: Interfaces para o usuário.
- `wwwroot/`: Recursos estáticos (CSS, JS, imagens).
- `appsettings.json`: Configurações do aplicativo.

---

## 💌 Contato

📧 Email: **eric_alegrete2002@hotmail.com**
🌐 LinkedIn: [Seu Perfil](https://linkedin.com/in/seuperfil)

