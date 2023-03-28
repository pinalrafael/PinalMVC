# PinalMVC [PT_BR]
- Software C# desktop para cria��o do projeto, atualiza��o da biblioteca, cria��o dos arquivos nos pad�es da biblioteca e edi��o dos arquivos do projeto.
- Biblioteca simples para padroniza��o de projetos em PHP no formato MVC.

-----
- [**Exemplo**](http://rafaelpinal.siteprofissional.com/PinalMVC/).
- [**Reposit�rio**](https://github.com/pinalrafael/PinalMVC).
- [**Releases**](https://github.com/pinalrafael/PinalMVC/releases).

-----
- Para informar argumentos � necess�rio informar a URL completa com o controller, function e id.
- Formato da URL: controller/function/id/arg0/arg1/arg2/arg3/...?par0=Value&par1=Value&par2=Value...

## INSTRU��ES DE FORMA AUTOM�TICA
1. Fa�a download e instale o software desktop PinalMVC.
2. Fa�a download e instale o xampp no dire�rio padr�o para que possa executar o projeto.
3. Para fazer atualiza��es no arquivo [httpd.conf] � necess�rio atualizar no arquivo [httpd_modelo.conf] da pasta [apache] na pasta de instala��o do PinalMVC.
4. Ao abrir o software pela primeira vez ser� baixado o notepad++ e o apache, caso o download n�o ocorra adicione as pastas [notepad] e [apache] na pasta de instala��o. 
5. Para criar um projeto clique em Novo Projeto.
	- Caminho (obrigat�rio): selecione o caminho onde ser� criado o projeto.
	- Nome (obrigat�rio): insira um nome para o projeto.
	- Sufixo Model (opcional): sufixo para os arquivos do Model. Ficar� ap�s o nome do arquivo e antes do .php.
	- Sufixo View (opcional): sufixo para os arquivos da View. Ficar� ap�s o nome do arquivo e antes do .php.
	- Sufixo Controller (opcional): sufixo para os arquivos do Controller. Ficar� ap�s o nome do arquivo e antes do .php.
	- Sufixo Page Error (opcional): sufixo para os arquivos das p�ginas de erro. Ficar� ap�s o nome do arquivo e antes do .php.
	- Clique em Criar para criar um projeto com as conficura��es iniciais.
6. Para abrir um projeto j� criado clique em Carregar Projeto e selecione o arquivo do projeto desejado.
7. Com o projeto aberto, para atualizar a biblioteca PinalMVC clique em Atualizar Biblioteca.
8. Com o projeto aberto, para atualizar adicionar arquivos padr�es de forma r�pida, clique em Novo Arquivo.
	- Nome (obrigat�rio): insira um nome para a rota e arquivos.
	- Criar (opcional): selecione os arquivos que deseja criar entre Model, View e Controller.
	- Controller (opcional): selecione as configura��es pad�es do seu controller entre CRUD e POST/GET.
	- P�gina (opcional): selecione se deseja criar como p�gina de erro ou p�gina de layout.
	- Layout (obrigat�rio): selecione a p�gina de layout que a view ser� exibida.
9. Use o click duplo sobre algum arquivo da �rvore para abrir o arquivo e editar.
10. Para executar o projeto clique em Executar Projeto e o apache ser� iniciado e o projeto ser� aberto no navegador.

## INSTRU��ES DE FORMA MANUAL
Os arquivos de [Sample] comtem um exemplo completo de uso da biblioteca e suas fun��es.

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

### CONFIGURANDO INDEX
1. Crie a pasta [Sample\includes\PinalMVC] ao seu projeto.

2. Crie as pastas [Controllers], [Models] e [Views] na raiz de seu projeto.

3. Crie as pastas [Layout] na pasta [Views] de seu projeto.

4. Crie seu arquivo [index.php].

5. Adicione o seguinte c�digo no arquivo [index.php].
```php
<?php
// Inclui a biblioteca principal.
include('includes/PinalMVC/main.php');
// Inclui a biblioteca para customiza��o do HTML.
include('includes/PinalMVC/customhtml.php');
// Inclui a biblioteca para a customiza��o das Rotas.
include('includes/PinalMVC/customroutes.php');

// Inicializa a biblioteca.
include('includes/PinalMVC/setup.php');
?>
```

6. Adicione o seguinte c�digo no arquivo [_Layout.php] em [Views\Layout].
```php
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

7. Configure o arquivo [_Layout.php] como desejar mas lembre-se de manter os include, [pmvcHead()], [require($pmvc_view)] e [pmvcBody()] no arquivo.

### CONFIGURANDO ARQUIVOS MODEL, VIEW E CONTROLLER
OBS: Todos os nomes de arquivos, pastas e fun��es devem ser iguais na integra.

1. Para criar uma view adicione a pasta com o nome desejado. Exemplo: [Teste].

2. Crie os arquivos views na pasta criada com as informa��es desejadas na pasta adicionada como no seguinte c�digo. Exemplo: [Index.php], [Create.php], [Update.php], [Delete.php] ou outro nome de fun��o que desejar.
```php
<h1>TESTE INDEX</h1>
```

3. Crie o arquivo [Teste.class.php] em [Models] para adicionar uma classe para [Teste] como no seguinte c�digo.
```php
<?php
class Teste{
	function __construct(){
		
	}
}
?>
```

4. Crie o arquivo [Teste.php] em [Controllers] com o seguinte c�digo.
```php
<?php
$pmvc_layout = "Views/Layout/_Layout.php";
$pmvc_title = "Teste";// Nome da p�gina.
$pmvc_Model = new Teste();// Criar um Model da p�gina.

function Index(){
	global $pmvc_title;// T�tulo da sua p�gina para acesso na fun��o
	global $pmvc_Model;// Model para acesso na fun��o
	global $pmvc_args;// URL argumentos para acesso na fun��o
	global $pmvc_custom_head;// Head tags customizados para acesso na fun��o
	global $pmvc_custom_body;// body tags customizados para acesso na fun��o
	global $pmvc_custom_routes_pars;// Pr�etros de rodas customizadas para acesso na fun��o

	// Seu c�digo GET

	if(isset($_POST)){// Seu c�digo POST
	}
}

function Create(){
	global $pmvc_title;// T�tulo da sua p�gina para acesso na fun��o
	global $pmvc_Model;// Model para acesso na fun��o
	global $pmvc_args;// URL argumentos para acesso na fun��o
	global $pmvc_custom_head;// Head tags customizados para acesso na fun��o
	global $pmvc_custom_body;// body tags customizados para acesso na fun��o
	global $pmvc_custom_routes_pars;// Pr�etros de rodas customizadas para acesso na fun��o

	if(isset($_POST)){
	}
}

function Update($id){
	global $pmvc_title;// T�tulo da sua p�gina para acesso na fun��o
	global $pmvc_Model;// Model para acesso na fun��o
	global $pmvc_args;// URL argumentos para acesso na fun��o
	global $pmvc_custom_head;// Head tags customizados para acesso na fun��o
	global $pmvc_custom_body;// body tags customizados para acesso na fun��o
	global $pmvc_custom_routes_pars;// Pr�etros de rodas customizadas para acesso na fun��o

	if(isset($_POST)){
	}
}

function Delete($id){
	global $pmvc_title;// T�tulo da sua p�gina para acesso na fun��o
	global $pmvc_Model;// Model para acesso na fun��o
	global $pmvc_args;// URL argumentos para acesso na fun��o
	global $pmvc_custom_head;// Head tags customizados para acesso na fun��o
	global $pmvc_custom_body;// body tags customizados para acesso na fun��o
	global $pmvc_custom_routes_pars;// Pr�etros de rodas customizadas para acesso na fun��o

	if(isset($_POST)){
	}
}

// Demais fun��es para views
?>
```

#### DICAS
- � poss�vel criar outras fun��es sem arquivo de view sendo apenas necess�rio chamar uma view j� criada. Veja [FUN��ES - 1.].

## DOCUMENTA��O
- index.php: arquivo index da raiz.
- Model: arquivo de classe modelo. Exemplo: Modelo.class.php.
- View: arqivo de visualiza��o da p�gina. Exemplo: Visualizacao/Index.php.
- Controller: arquivo de fun��es do controlador. Exemplo: Controlador.php.
- main.php: arquivo main com as fun��es principais.
- customroutes.php: arquivo com as fun��es de rotas personalizadas
- customhtml.php: arquivo com as fun��es de html personalizadas
- setup.php: arquivo com o setup da biblioteca, deve ser incluido depois das configura��es da biblioteca.

### VARI�VEIS
1. Exibe a vers�o da biblioteca. 
```php
<?php 
echo $pmvc_version; 
?>
```

2. Informa e exibe o t�tulo da p�gina. 
```php
<?php 
// No controller
$pmvc_title = "T�tulo";

// No index.php
?>
<title>... <?php echo $pmvc_title; ?> ...</title>
```

3. Manibulando o Model. 
```php
<?php 
// No controller
$pmvc_Model = new ModelClass();

// Na function
$pmvc_Model->classobject = "Valor do objeto";

// Na view
echo $pmvc_Model->classobject;
?>
```

4. Informa e exibe tags do head customizadas. Ser� exibido em [FUN��ES - 8.]
```php
<?php 
$pmvc_custom_head = "<style>...</style><meta...>";
?>
```

5. Informa e exibe tags do body customizadas. Ser� exibido em [FUN��ES - 9.]
```php
<?php 
$pmvc_custom_body = "<script>...</script>";
?>
```

6. Exibe argumentos da URL. controller/function/id/arg0/arg1/arg2/arg3/...
```php
<?php 
// Deve ser usada ap�s o main.php
echo $pmvc_args["controller"];
echo $pmvc_args["function"];
echo $pmvc_args["id"];
echo $pmvc_args["arg0"];
echo $pmvc_args["arg1"];
echo $pmvc_args["arg2"];
...
?>
```

7. Exibe par�metros da URL. controller/function/id?par0=Value&par1=Value&par2=Value
```php
<?php 
echo $_GET["par0"];
echo $_GET["par1"];
echo $_GET["par2"];
...
?>
```

8. Exibe par�metros de view informados na fun��o pmvcView($controller, $function, $pars = array()).
- key: valor do kay/index informado em $pars. Para informar os par�metros [FUN��ES - 1.]
```php
<?php 
echo $pmvc_pars[key];
?>
```

9. Informa a p�gina de layout no Controller.
```php
<?php 
$pmvc_layout = "Views/Layout/_Layout.php";
?>

10. Informa o caminho root do projeto. Configurado em [FUN��ES - 2.]
```php
<?php 
echo $pmvc_root;
?>
```

11. Informa os par�metros enviados em [FUN��ES - 10.]
```php
<?php 
echo $pmvc_custom_routes_pars;
?>
```

### FUN��ES
1. pmvcView: Chamar uma view no controller. Por padr�o ser� chamada a view com o nome da function.
- $controller: nome do controller que se encontra a view.
- $function: nome da fun��o do controller que se encontra a view.
- $pars: array de par�metros opcionais que podem ser enviados para a view. Para receber os par�metros veja [VARI�VEIS - 8.]
```php
<?php 
// Sem par�metros
pmvcView('Controlador', 'Funcao');

// Com par�metros
pmvcView('Controlador', 'Funcao', array( 'key' => 'value' ));
?>
```

2. pmvcSetRoot: Configurar a pasta raiz do software no servidor. Opcional, o padr�o ser� '/'.
- $root: nome do controller que se encontra a view.
```php
<?php 
// No index.php ap�s o include do main
pmvcSetRoot("/Pasta/");
?>
```

3. pmvcGetValueController: Recebe o valor do Controller atual.
```php
<?php 
echo pmvcGetValueController();
?>
```

4. pmvcGetValueFunction: Recebe o valor da function atual.
```php
<?php 
echo pmvcGetValueFunction();
?>
```

5. pmvcGetValueId: Recebe o valor do id atual.
```php
<?php 
echo pmvcGetValueId();
?>
```

6. pmvcCSS: Adiciona um CSS customizado. Ser� exibido em [FUN��ES - 8.].
- $customArray: array com os atributos e valores da tag link.
	- 'Key' => 'Value'.
```php
<?php 
mvcCSS(array( 'href' => 'URL to css', 'rel' => 'stylesheet' ));
?>
```

7. pmvcScript: Adiciona um Script customizado. Ser� exibido em [FUN��ES - 9.].
- $customArray: array com os atributos e valores da tag script.
	- 'Key' => 'Value'.
```php
<?php 
pmvcScript(array( 'src' => 'URL to script' ));
?>
```

8. pmvcHead: Gera o Head customizado.
```php
<head>... <?php
// No index.php
echo pmvcHead(); 
?> ...</head>
```

9. pmvcBody: Gera o Body customizado.
```php
<body>... <?php 
// No index.php
echo pmvcBody(); 
?> ...</body>
```

10. pmvcCustomRoutes: Adiciona uma rota customizada.
- $customArray: array da rota customizada.
	- type: Tipo de rota: C -> Controller, F -> Function e I -> Id.
	- original: Valor original da rota no c�digo e arquivos.
	- custom: Valor da rota customizada em URL.
	- params (opcional): Valor que pode ser enviado para as rotas e acessado no controller.
```php
<?php
// No index.php ap�s o include do main, customroutes e antes do setup.

// Se chamar custom_controller na sua URL, o arquivo CustomControllerRoute.php ser� chamado.
pmvcCustomRoutes(array( 'type' => 'C', 
'original' => 'CustomControllerRoute', 
'custom' => 'custom_controller' ));

// Se chamar custom_function na sua URL, a fun��o CustomFunctionRoute ser� chamada no controller.
pmvcCustomRoutes(array( 'type' => 'F', 
'original' => 'CustomFunctionRoute', 
'custom' => 'custom_function' ));

// Se chamar custom_id na sua URL, o Id 0123456789 ser� retornado em pmvcGetValueId().
pmvcCustomRoutes(array( 'type' => 'I', 
'original' => '0123456789', 
'custom' => 'custom_id' ));

// Ao passar um params na sua configura��o de rota voc� podera acessar esse valor controller.
pmvcCustomRoutes(array( 'type' => 'F', 
'original' => 'CustomFunctionRouteParams', 
'custom' => 'custom_function_params',
'params' => array(0, 1, 2, 3, 4)));
?>
```

### CONFIGURA��ES JSON
Arquivo json de configura��es da biblioteca em: [includes\PinalMVC\config.json].
#### ATEN��O: AO ATUALIZAR A BIBLIOTECA, CASO TENHA ALTERADO O ARQUIVO DE CONFIGURA��ES SER� NECESS�RIO ATUALIZA-LO MANUALMENTE PARA N�O PERDER SUAS CONFIGURA��ES.
- root: pasta root do projeto, o mesmo pode substituir a fun��o [pmvcSetRoot()].
- models: pasta de arquivos de modelos sendo iniciado na raiz do projeto.
- views: pasta de arquivos de views sendo iniciado na raiz do projeto.
- controllers: pasta de arquivos de controllers sendo iniciado na raiz do projeto.
- page_errors: pasta de views de erros sendo iniciado na raiz do projeto.
- models_suffix: sufixo dos arquivos de modelo no formato: Nome[Sufixo].php.
- views_suffix: sufixo dos arquivos de views no formato: Nome[Sufixo].php. N�o informar na URL.
- controllers_suffix: sufixo dos arquivos de controller no formato: Nome[Sufixo].php. N�o informar na URL.
- page_errors_suffix: sufixo dos arquivos de views de erros no formato: Nome[Sufixo].php. N�o informar na URL.

## DICAS
- � poss�vel configurar as rotas no banco de dados de forma din�mica, usando $pmvc_args["controller"] ou $pmvc_args["function"] ou $pmvc_args["id"] para acessar os seus valores da URL e buscar o valor de 'original'. Veja [VARI�VEIS - 6.] e [FUN��ES - 10.].

## SUPORTE
- Bugs, d�vidas e sugest�es? Crie um issue.
- [**Meu Portf�lio**](http://rafaelpinal.siteprofissional.com/).
- [**Siga-me**](https://github.com/pinalrafael?tab=followers) para minhas pr�ximas cria��es.
