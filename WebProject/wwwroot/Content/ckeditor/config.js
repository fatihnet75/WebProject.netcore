/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	 config.language = 'tr';
	 config.uiColor = '#9AB8F3';
	 config.colorButton_colors = '000000,FF0000,00FF00,0000FF';//yaz� renk butonunun renkleri
	 config.colorButton_enableMore = true; //belirtilenler d���nda renk  se�imini  engelleme
	 config.contentsLanguage = 'tr';//Edit�r i�eri�i olu�turmak i�in kullan�lan yaz� dilinin dil kodu.
    //Dosya Y�neticisi
	 config.filebrowserBrowseUrl = '/fileman/index.html';// �ntan�ml� Dosya Y�neticisi
	 config.filebrowserImageBrowseUrl = '/fileman/index.html?type=image'; // Sadece Resim Dosyalar�n� G�steren Dosya Y�neticisi
	 config.removeDialogTabs = 'link:upload;image:upload'; // Upload i�lermlerini dosya Y�neticisi ile yapaca��m�z i�in upload butonlar�n� kald�r�yoruz
};
