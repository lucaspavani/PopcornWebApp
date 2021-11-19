<h2>PopcornWebApp</h2>

Bem vindo! :popcorn:

​	O <strong>PopcornWebApp</strong> é um sistema web feito utilizando o ASP.NET Core e o Entity 

Framework Core no padrão de projetos de software MVC (Model-View-Controller). 

​	Seu objetivo é <strong>gerenciar um cinema</strong>.

<hr>

<h3>Como executar o projeto?</h3>

<ul>
  <li>É necessário ter instalado o <a href="https://visualstudio.microsoft.com/pt-br/downloads/">Visual Studio</a></p></li>
  <li>Faça o download ou clone este repositório</li>
  <li>Abra o arquivo "PopcornWebApp.sln" no Visual Studio</li>
  <li>No Packet Manager, execute o comando "update-database"</li>
  <li>Clique em "IIS Express" no topo da janela</li>
</ul>  

<hr>

<h3>Requisitos</h3>

O gerenciador de cinema é uma ferramenta responsável por criar, editar e deletar
recursos. As operações devem ficar disponíveis apenas após o usuário efetuar o login
com as credenciais de gerente.&#10004;

<hr>

<h4>Gerenciamento de filmes</h4>

<ol>
    <li>Todo filme deve conter:</li>
    	<ol type="a">
            <li>Imagem;&#10004;</li>
            <li>Título;&#10004;</li>
            <li>Descrição;&#10004;</li>
            <li>Duração.&#10004;</li>
    </ol>
    <li>Deve ser possível cadastrar, editar e remover filmes.&#10004;</li>
    <li>Filmes não podem ter títulos repetidos.&#10004;</li>
    <li>Um filme só pode ser excluído se não ouver sessões vinculadas.&#10004*</li>
    <li>Devem ser desenvolvidos testes de unidade.❌</li>
</ol>

<hr>

* Item 4: Tentei fazer de forma similar ao item 3, porém a mensagem de erro não é exibida, preciso trabalhar nisso. De toda forma, filmes vinculados à sessões, não podem ser excluídos.

<hr>

<h4>Lista de salas</h4>

<ol>
    <li>A sala deve conter:</li>
    	<ol type="a">
            <li>Nome;&#10004;</li>
            <li>Quantidade de assentos.&#10004;</li>
    </ol>
    <li>As salas devem estar pré cadastradas no sistema.❌</li>
    <li>Deve possuir uma tela para visualização das salas.&#10004;</li>
    <li>Não é necessária nenhuma operação com as salas.❌</li>
</ol>

<hr>

* Itens 2 e 3: Não consegui deixar as salas pré cadastradas, então deixei as funções Create e Delete, creio que seria possível com uma ViewBag, mas tive dificuldade para implementar em tempo hábil.

<hr>

<h4>Gerenciamento de sessões</h4>

<ol>
    <li>Todo sessão deve:</li>
    	<ol type="a">
            <li>Conter uma data;&#10004;</li>
            <li>Conter um horário de início;&#10004;</li>
            <li>Conter um horário de fim;&#10004;*</li>
            <li>Conter um valor do ingresso;&#10004;</li>
            <li>Conter um tipo de animação (3d ou 2d);&#10004;*</li>
            <li>Conter um tipo de áudio (original ou dublado)&#10004;*</li>
            <li>Estar vinculada a um filme;&#10004;</li>
            <li>Estar vinculada a uma sala.&#10004;</li>
    </ol>
    <li>Deve ser possível cadastrar e remover sessões.&#10004;</li>
    <li>O horário final não deve ser inserido pelo usuário, deve ser calculado
automaticamente, tendo como base o horário de início e a duração do filme
selecionado.❌</li>
    <li>Deve-se permitir somente selecionar salas que estão com horário disponível, ou
seja, se uma sala já estiver vinculada a outra sessão que contém o horário dentro
do intervalo do horário selecionado para a sessão sendo criada, então esta sala
não deve ser exibida. Resumidamente, a mesma sala não pode passar dois ou
mais filmes ao mesmo tempo.&#10004;*</li>
    <li>Uma sessão só pode ser removida se faltar 10 dias ou mais para que ela ocorra.&#10004;*</li>
    <li>Devem ser desenvolvidos testes de unidade.❌</li>
</ol>

<hr>

* Item 1.c e 3: Não consegui pensar em uma maneira de fazer esta operação, embora tenha algumas ideias, não consegui implementar;
* Itens 1.e e 1.f: Assim como as salas, deveriam estar pré cadastrados no sistema, como não consegui, deixei possível que tipos de áudio e animação fossem criados/deletados, para que eu pudesse criar uma sessão com todos os dados necessários.
* Item 4: Utilizei uma função para verificar se os intervalos estão sendo utilizados, provavelmente deve existir alguma forma mais simples de se obter o mesmo resultado, porém não consegui impedir que a sala fosse exibida no dropdown menu de criação de sessões.
* Item 5: Tive que usar uma "solução temporária" que apenas não exibe o botão de delete sob a condição requisitada.

<hr>

<h4>Testes unitários</h4>

Não foram realizados testes unitários, ainda estou estudando a respeito.

