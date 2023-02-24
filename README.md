# PT_BR
Biblioteca simples para padroniza��o de projetos em PHP no formato MVC.

## INSTRU��ES
Os arquivos de [Sample] comtem um exemplo de uso da biblioteca e suas fun��es.

### CONFIGURA��ES DO SERVIDOR
1. Adicione o [mod_rewrite] no arquivo [.htaccess].
```xml
<IfModule mod_rewrite.c>
RewriteEngine On
RewriteCond %{REQUEST_FILENAME} !-f
RewriteCond %{REQUEST_FILENAME} !-d
RewriteRule ^(.*)$ index.php/?request=$1 [QSA,L,NC]
</IfModule>
```

### IMPORTAR BIBLIOTECA
1. Adicione a pasta [Sample\includes\PinalMVC] ao seu projeto.
2. Adicione as pastas [Controllers], [Models] e [Views] na raiz de seu projeto.
3. Crie seu arquivo [index.php].
4. Adicione o seguinte c�digo no arquivo [index.php].
```php
<?php
include('includes/PinalMVC/main.php');// Inclui a biblioteca adicionada no item 1.

pmvcSetRoot("/Test/");// Opcional para quando adicioner em uma sub pasta da raiz do servidor. Se n�o informar ser� '/'.

?>
<!DOCTYPE html>
<html>
	<head>
		<!-- ADICIONE SUAS TAGS DO HEAD DO SITE -->

		<?php pmvcHead(); ?>
	</head>
	<body>
	
	<?php require($pmvc_view); ?>

	<!-- ADICIONE SEUS SCRIPTS DO SITE -->

	<?php pmvcBody(); ?>
	</body>
</html>
```
4. Configure o arquivo [index.php] como desejar mas lembre-se de manter os [pmvcHead()], [require($pmvc_view)] e [pmvcBody()] no arquivo.

### USANDO A BIBLIOTECA
OBS: Todos os nomes de arquivos, pastas e fun��es devem ser iguais na integra.
1. Para criar uma view adicione a pasta com o nome desejado. Exemplo: [Teste].
2. Crie os arquivos views na pasta criada com as informa��es desejadas na pasta adicionada. Exemplo: [Index.php], [Create.php], [Update.php] e [Delete.php].
3. Crie o arquivo [Teste.class.php] em [Models] para adicionar classes ao seu projeto.
4. Crie o arquivo [Teste.php] em [Controllers] com o seguinte c�digo.
```php
<?php

$pmvc_title = "Teste";// Nome da p�gina.
$pmvc_Model = new Teste();// Criar um Model da p�gina.

if(pmvcGetValueFunction() == "Index"){// Nomes dos arquivos e fun��es como criados no item 2.
	if(isset($_GET)){// Recebe um GET na p�gina.
		
	} else if(isset($_POST)){// Recebe um POST na p�gina.
	
	}
}else if(pmvcGetValueFunction() == "Create"){
	if(isset($_GET)){
		
	} else if(isset($_POST)){
	
	}
}else if(pmvcGetValueFunction() == "Update"){
	if(isset($_GET)){
		
	} else if(isset($_POST)){
		
	}
}else if(pmvcGetValueFunction() == "Delete"){
	if(isset($_GET)){
		
	} else if(isset($_POST)){
	
	}
}else{
	pmvcView("PagesErrors", "Error404", array('msg' => 'Fun��o: '.pmvcGetValueFunction().' n�o encontrada!'));
}
// � poss�vel criar outras fun��es sem arquivos em views sendo apenas necess�rio chamar uma view.
?>
```

## DOCUMENTA��O
1. Vari�veis:
$pmvc_version: Exibe a vers�o da biblioteca.
$pmvc_title: Adicionado em cada Controller para informar o t�tulo da p�gina que ser� exibido.
$pmvc_Model: Classe modelo.
$pmvc_custom_head: String com tags adicionais em Head. Exemplo: <style>...</style><meta...>
$pmvc_custom_body: String com tags adicionais em Body. Exemplo: <script>...</script>
$pmvc_args: Argumentos adicionais da URL. Exemplo: Controller/Function/Id/Arg0/Arg1/Arg2/Arg3/... para acessar use: $pmvc_args["arg0"]...
$_GET["par1"]...: Para acessar os par�metros da URL. Exemplo: Controller/Function/Id?par1=Value&par2=Value&par3=Value
$pmvc_pars: Exibe os par�metros informados em [pmvcView]. Exemplo: $pmvc_pars[key]
2. Fun��es:
pmvcView($controller, $function, $pars = array()): Adiciona uma view para uma fun��o do controller sem view.
pmvcSetRoot($root): Atualiza a pasta root.
pmvcGetValueController(): Recebe o valor do Controller atual.
pmvcGetValueFunction(): Recebe o valor da function atual.
pmvcGetValueId(): Recebe o valor do id atual.
pmvcHead(): Gera o Head customizado.
pmvcBody(): Gera o Body customizado.
pmvcCSS($customArray): Adiciona um CSS customizado. Exemplo: array( 'href' => 'URL to css', rel => 'stylesheet' ).
pmvcScript($customArray): Adiciona um Script customizado. Exemplo: array custom array( 'src' => 'URL to script' ).