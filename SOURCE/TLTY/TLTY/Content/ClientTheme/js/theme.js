function getCookie(cname) {
	var name = cname + "=";
	var ca = document.cookie.split(';');
	for (var i = 0; i < ca.length; i++) {
		var c = ca[i].trim();
		if (c.indexOf(name) === 0) return c.substring(name.length, c.length);
	}
	return "";
}

var style_cookie_name = "style";
var style_cookie_duration = 30;

function switch_style(cssTitle) {
	var i, linkTag;
	for (i = 0, linkTag = document.getElementsByTagName("link") ; i < linkTag.length; i++) {
		if ((linkTag[i].rel.indexOf("stylesheet") !== -1) && linkTag[i].title) {
			linkTag[i].disabled = true;
			if (linkTag[i].title === cssTitle) {
				linkTag[i].disabled = false;
			}
		}
		set_cookie(style_cookie_name, cssTitle, style_cookie_duration);
	}
}

function set_style_from_cookie() {
	var cssTitle = getCookie(style_cookie_name);
	if (cssTitle.length) {
		switch_style(cssTitle);
		//alert('Đang chọn ' + cssTitle);
	}
}

//Lưu cookie
function set_cookie(cookieName, cookieValue, lifespanInDays) {
	document.cookie = cookieName + "=" + encodeURIComponent(cookieValue) + "; max-age=" + 60 * 60 * 24 * lifespanInDays + "; path=/";
}

//Gọi cookie lên
function get_cookie(cookieName) {
	var cookieString = document.cookie;
	var re = new RegExp("(^|;)[\s]*" + cookieName + "=([^;]*)");
	if (cookieString.length !== 0) {
		var cookieValue = cookieString.match(re);
		return decodeURIComponent(cookieValue[2]);
	}
	return '';
}