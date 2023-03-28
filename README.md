# PinalMVC [PT_BR]
- Software C# desktop para criação do projeto, atualização da biblioteca, criação dos arquivos nos padões da biblioteca e edição dos arquivos do projeto.
- Biblioteca simples para padronização de projetos em PHP no formato MVC.

-----
- [**Exemplo**](http://rafaelpinal.siteprofissional.com/PinalMVC/).
- [**Repositório**](https://github.com/pinalrafael/PinalMVC).
- [**Releases**](https://github.com/pinalrafael/PinalMVC/releases).

-----
- Para informar argumentos é necessário informar a URL completa com o controller, function e id.
- Formato da URL: controller/function/id/arg0/arg1/arg2/arg3/...?par0=Value&par1=Value&par2=Value...

## INSTRUÇÕES DE FORMA AUTOMÁTICA
1. Faça download e instale o software desktop PinalMVC.
2. Faça download e instale o xampp no direório padrão para que possa executar o projeto.
3. Para fazer atualizações no arquivo [httpd.conf] é necessário atualizar no arquivo [httpd_modelo.conf] da pasta [apache] na pasta de instalação do PinalMVC.
4. Ao abrir o software pela primeira vez será baixado o notepad++ e o apache, caso o download não ocorra adicione as pastas [notepad] e [apache] na pasta de instalação. 
5. Para criar um projeto clique em Novo Projeto.
	- Caminho (obrigatório): selecione o caminho onde será criado o projeto.
	- Nome (obrigatório): insira um nome para o projeto.
	- Sufixo Model (opcional): sufixo para os arquivos do Model. Ficará após o nome do arquivo e antes do .php.
	- Sufixo View (opcional): sufixo para os arquivos da View. Ficará após o nome do arquivo e antes do .php.
	- Sufixo Controller (opcional): sufixo para os arquivos do Controller. Ficará após o nome do arquivo e antes do .php.
	- Sufixo Page Error (opcional): sufixo para os arquivos das páginas de erro. Ficará após o nome do arquivo e antes do .php.
	- Clique em Criar para criar um projeto com as conficurações iniciais.
6. Para abrir um projeto já criado clique em Carregar Projeto e selecione o arquivo do projeto desejado.
7. Com o projeto aberto, para atualizar a biblioteca PinalMVC clique em Atualizar Biblioteca.
8. Com o projeto aberto, para atualizar adicionar arquivos padrões de forma rápida, clique em Novo Arquivo.
	- Nome (obrigatório): insira um nome para a rota e arquivos.
	- Criar (opcional): selecione os arquivos que deseja criar entre Model, View e Controller.
	- Controller (opcional): selecione as configurações padões do seu controller entre CRUD e POST/GET.
	- Página (opcional): selecione se deseja criar como página de erro ou página de layout.
	- Layout (obrigatório): selecione a página de layout que a view será exibida.
9. Use o click duplo sobre algum arquivo da árvore para abrir o arquivo e editar.
10. Para executar o projeto clique em Executar Projeto e o apache será iniciado e o projeto será aberto no navegador.

## INSTRUÇÕES DE FORMA MANUAL
Os arquivos de [Sample] comtem um exemplo completo de uso da biblioteca e suas funções.

### CONFIGURAÇÕES DO SERVIDOR
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

5. Adicione o seguinte código no arquivo [index.php].
```php
<?php
// Inclui a biblioteca principal.
include('includes/PinalMVC/main.php');
// Inclui a biblioteca para customização do HTML.
include('includes/PinalMVC/customhtml.php');
// Inclui a biblioteca para a customização das Rotas.
include('includes/PinalMVC/customroutes.php');

// Inicializa a biblioteca.
include('includes/PinalMVC/setup.php');
?>
```

6. Adicione o seguinte código no arquivo [_Layout.php] em [Views\Layout].
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
OBS: Todos os nomes de arquivos, pastas e funções devem ser iguais na integra.

1. Para criar uma view adicione a pasta com o nome desejado. Exemplo: [Teste].

2. Crie os arquivos views na pasta criada com as informações desejadas na pasta adicionada como no seguinte código. Exemplo: [Index.php], [Create.php], [Update.php], [Delete.php] ou outro nome de função que desejar.
```php
<h1>TESTE INDEX</h1>
```

3. Crie o arquivo [Teste.class.php] em [Models] para adicionar uma classe para [Teste] como no seguinte código.
```php
<?php
class Teste{
	function __construct(){
		
	}
}
?>
```

4. Crie o arquivo [Teste.php] em [Controllers] com o seguinte código.
```php
<?php
$pmvc_layout = "Views/Layout/_Layout.php";
$pmvc_title = "Teste";// Nome da página.
$pmvc_Model = new Teste();// Criar um Model da página.

function Index(){
	global $pmvc_title;// Título da sua página para acesso na função
	global $pmvc_Model;// Model para acesso na função
	global $pmvc_args;// URL argumentos para acesso na função
	global $pmvc_custom_head;// Head tags customizados para acesso na função
	global $pmvc_custom_body;// body tags customizados para acesso na função
	global $pmvc_custom_routes_pars;// Prâetros de rodas customizadas para acesso na função

	// Seu código GET

	if(isset($_POST)){// Seu código POST
	}
}

function Create(){
	global $pmvc_title;// Título da sua página para acesso na função
	global $pmvc_Model;// Model para acesso na função
	global $pmvc_args;// URL argumentos para acesso na função
	global $pmvc_custom_head;// Head tags customizados para acesso na função
	global $pmvc_custom_body;// body tags customizados para acesso na função
	global $pmvc_custom_routes_pars;// Prâetros de rodas customizadas para acesso na função

	if(isset($_POST)){
	}
}

function Update($id){
	global $pmvc_title;// Título da sua página para acesso na função
	global $pmvc_Model;// Model para acesso na função
	global $pmvc_args;// URL argumentos para acesso na função
	global $pmvc_custom_head;// Head tags customizados para acesso na função
	global $pmvc_custom_body;// body tags customizados para acesso na função
	global $pmvc_custom_routes_pars;// Prâetros de rodas customizadas para acesso na função

	if(isset($_POST)){
	}
}

function Delete($id){
	global $pmvc_title;// Título da sua página para acesso na função
	global $pmvc_Model;// Model para acesso na função
	global $pmvc_args;// URL argumentos para acesso na função
	global $pmvc_custom_head;// Head tags customizados para acesso na função
	global $pmvc_custom_body;// body tags customizados para acesso na função
	global $pmvc_custom_routes_pars;// Prâetros de rodas customizadas para acesso na função

	if(isset($_POST)){
	}
}

// Demais funções para views
?>
```

#### DICAS
- É possível criar outras funções sem arquivo de view sendo apenas necessário chamar uma view já criada. Veja [FUNÇÕES - 1.].

## DOCUMENTAÇÃO
- index.php: arquivo index da raiz.
- Model: arquivo de classe modelo. Exemplo: Modelo.class.php.
- View: arqivo de visualização da página. Exemplo: Visualizacao/Index.php.
- Controller: arquivo de funções do controlador. Exemplo: Controlador.php.
- main.php: arquivo main com as funções principais.
- customroutes.php: arquivo com as funções de rotas personalizadas
- customhtml.php: arquivo com as funções de html personalizadas
- setup.php: arquivo com o setup da biblioteca, deve ser incluido depois das configurações da biblioteca.

### VARIÁVEIS
1. Exibe a versão da biblioteca. 
```php
<?php 
echo $pmvc_version; 
?>
```

2. Informa e exibe o título da página. 
```php
<?php 
// No controller
$pmvc_title = "Título";

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

4. Informa e exibe tags do head customizadas. Será exibido em [FUNÇÕES - 8.]
```php
<?php 
$pmvc_custom_head = "<style>...</style><meta...>";
?>
```

5. Informa e exibe tags do body customizadas. Será exibido em [FUNÇÕES - 9.]
```php
<?php 
$pmvc_custom_body = "<script>...</script>";
?>
```

6. Exibe argumentos da URL. controller/function/id/arg0/arg1/arg2/arg3/...
```php
<?php 
// Deve ser usada após o main.php
echo $pmvc_args["controller"];
echo $pmvc_args["function"];
echo $pmvc_args["id"];
echo $pmvc_args["arg0"];
echo $pmvc_args["arg1"];
echo $pmvc_args["arg2"];
...
?>
```

7. Exibe parâmetros da URL. controller/function/id?par0=Value&par1=Value&par2=Value
```php
<?php 
echo $_GET["par0"];
echo $_GET["par1"];
echo $_GET["par2"];
...
?>
```

8. Exibe parâmetros de view informados na função pmvcView($controller, $function, $pars = array()).
- key: valor do kay/index informado em $pars. Para informar os parâmetros [FUNÇÕES - 1.]
```php
<?php 
echo $pmvc_pars[key];
?>
```

9. Informa a página de layout no Controller.
```php
<?php 
$pmvc_layout = "Views/Layout/_Layout.php";
?>

10. Informa o caminho root do projeto. Configurado em [FUNÇÕES - 2.]
```php
<?php 
echo $pmvc_root;
?>
```

11. Informa os parâmetros enviados em [FUNÇÕES - 10.]
```php
<?php 
echo $pmvc_custom_routes_pars;
?>
```

### FUNÇÕES
1. pmvcView: Chamar uma view no controller. Por padrão será chamada a view com o nome da function.
- $controller: nome do controller que se encontra a view.
- $function: nome da função do controller que se encontra a view.
- $pars: array de parâmetros opcionais que podem ser enviados para a view. Para receber os parâmetros veja [VARIÁVEIS - 8.]
```php
<?php 
// Sem parâmetros
pmvcView('Controlador', 'Funcao');

// Com parâmetros
pmvcView('Controlador', 'Funcao', array( 'key' => 'value' ));
?>
```

2. pmvcSetRoot: Configurar a pasta raiz do software no servidor. Opcional, o padrão será '/'.
- $root: nome do controller que se encontra a view.
```php
<?php 
// No index.php após o include do main
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

6. pmvcCSS: Adiciona um CSS customizado. Será exibido em [FUNÇÕES - 8.].
- $customArray: array com os atributos e valores da tag link.
	- 'Key' => 'Value'.
```php
<?php 
mvcCSS(array( 'href' => 'URL to css', 'rel' => 'stylesheet' ));
?>
```

7. pmvcScript: Adiciona um Script customizado. Será exibido em [FUNÇÕES - 9.].
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
	- original: Valor original da rota no código e arquivos.
	- custom: Valor da rota customizada em URL.
	- params (opcional): Valor que pode ser enviado para as rotas e acessado no controller.
```php
<?php
// No index.php após o include do main, customroutes e antes do setup.

// Se chamar custom_controller na sua URL, o arquivo CustomControllerRoute.php será chamado.
pmvcCustomRoutes(array( 'type' => 'C', 
'original' => 'CustomControllerRoute', 
'custom' => 'custom_controller' ));

// Se chamar custom_function na sua URL, a função CustomFunctionRoute será chamada no controller.
pmvcCustomRoutes(array( 'type' => 'F', 
'original' => 'CustomFunctionRoute', 
'custom' => 'custom_function' ));

// Se chamar custom_id na sua URL, o Id 0123456789 será retornado em pmvcGetValueId().
pmvcCustomRoutes(array( 'type' => 'I', 
'original' => '0123456789', 
'custom' => 'custom_id' ));

// Ao passar um params na sua configuração de rota você podera acessar esse valor controller.
pmvcCustomRoutes(array( 'type' => 'F', 
'original' => 'CustomFunctionRouteParams', 
'custom' => 'custom_function_params',
'params' => array(0, 1, 2, 3, 4)));
?>
```

### CONFIGURAÇÕES JSON
Arquivo json de configurações da biblioteca em: [includes\PinalMVC\config.json].
#### ATENÇÃO: AO ATUALIZAR A BIBLIOTECA, CASO TENHA ALTERADO O ARQUIVO DE CONFIGURAÇÕES SERÁ NECESSÁRIO ATUALIZA-LO MANUALMENTE PARA NÃO PERDER SUAS CONFIGURAÇÕES.
- root: pasta root do projeto, o mesmo pode substituir a função [pmvcSetRoot()].
- models: pasta de arquivos de modelos sendo iniciado na raiz do projeto.
- views: pasta de arquivos de views sendo iniciado na raiz do projeto.
- controllers: pasta de arquivos de controllers sendo iniciado na raiz do projeto.
- page_errors: pasta de views de erros sendo iniciado na raiz do projeto.
- models_suffix: sufixo dos arquivos de modelo no formato: Nome[Sufixo].php.
- views_suffix: sufixo dos arquivos de views no formato: Nome[Sufixo].php. Não informar na URL.
- controllers_suffix: sufixo dos arquivos de controller no formato: Nome[Sufixo].php. Não informar na URL.
- page_errors_suffix: sufixo dos arquivos de views de erros no formato: Nome[Sufixo].php. Não informar na URL.

## DICAS
- É possível configurar as rotas no banco de dados de forma dinâmica, usando $pmvc_args["controller"] ou $pmvc_args["function"] ou $pmvc_args["id"] para acessar os seus valores da URL e buscar o valor de 'original'. Veja [VARIÁVEIS - 6.] e [FUNÇÕES - 10.].

## SUPORTE
- Bugs, dúvidas e sugestões? Crie um issue.
- [**Meu Portfólio**](http://rafaelpinal.siteprofissional.com/).
- [**Siga-me**](https://github.com/pinalrafael?tab=followers) para minhas próximas criações.
