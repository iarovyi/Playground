INSTALL
1) install сервер (nodejs) https://nodejs.org/en/download/
2) install редактор (visual studio code) https://code.visualstudio.com/
3) install поддержку интелисенса в редакторе (dariofuzinato.vue-peek)
4) install генератор шаблонов (vue-cli) 
   npm install -g vue-cli   #https://github.com/vuejs/vue-cli
5) install сервер для случая когда мы используем simple template
   npm install -g live-server

GENERATE WEBSITE
6) сгенерировать шаблон  
    vue init simple <MY PROJECT NAME>          - без webpack
	vue init webpack-simple <MY PROJECT NAME>  - простой с webpack
	vue init webpack <MY PROJECT NAME>         - сложный с webpack
7) сделать текущей папку проекта cd .\<MY PROJECT NAME>
8) скачать зависомости для сгенерированого шаблона
   npm install
   
RUN
9) сделать текущей папку проекта cd .\путь к папке
10) запустить сайт
    10.1) в случае webpack
	     npm run dev
	
	10.2) в случае simple     (https://github.com/vuejs-templates/simple)
	     live-server
	
	
DEPLOY
11) создать продакшн версию
    11.1) в случае webpack
	       npm run build
	11.2) в случае simple 
	      ничего не надо делать, все файлы готовы
-------------------------------------------------------------------


