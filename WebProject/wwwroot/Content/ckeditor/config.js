/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	 config.language = 'tr';
	 config.uiColor = '#9AB8F3';
	 config.colorButton_colors = '000000,FF0000,00FF00,0000FF';//yazý renk butonunun renkleri
	 config.colorButton_enableMore = true; //belirtilenler dýþýnda renk  seçimini  engelleme
	 config.contentsLanguage = 'tr';//Editör içeriði oluþturmak için kullanýlan yazý dilinin dil kodu.
    //Dosya Yöneticisi
	 config.filebrowserBrowseUrl = '/fileman/index.html';// Öntanýmlý Dosya Yöneticisi
	 config.filebrowserImageBrowseUrl = '/fileman/index.html?type=image'; // Sadece Resim Dosyalarýný Gösteren Dosya Yöneticisi
	 config.removeDialogTabs = 'link:upload;image:upload'; // Upload iþlermlerini dosya Yöneticisi ile yapacaðýmýz için upload butonlarýný kaldýrýyoruz
};
