/*------------------------------------------------------------------------------------
* Archivo: UtilAjax.js
* Descripcion: Funciones para el control de ventanas modal y modales
* Autor: Luís A. Mascaro Jácome
* Fecha: 15/09/2005
*------------------------------------------------------------------------------------*/

function Ajax() {
	var ecState = {
		uninitialized: 0,
		loading: 1,
		loaded: 2,
		interactive: 3,
		completed: 4
	}
	
	var ecHttpStatus = {
		OK: 200
	}

	this.req = null;
	this.url = null;
	this.method = 'GET';
	this.async = true;
	this.status = null;
	this.statusText = '';
	this.postData = null;
	this.readyState = null;
	this.responseText = null;
	this.responseXML = null;
	this.handleResp = null;
	this.responseFormat = 'text'; // 'text', 'xml', or 'object'
	this.mimeType = null;
	this.data = new Array();
	this.extraRespParam = null;
	
	this.init = function() {
		if (!this.req) {
			try {
				// crea un objeto para Firefox, Safari, IE7, etc.
				this.req = new XMLHttpRequest();
			}
			catch(e) {
				try {
					// crea un objeto para las ultimas versiones de IE.
					this.req = new ActiveXObject('MSXML2.XMLHTTP');
				}
				catch(e) {
					try {
						// crea un objeto para recientes versiones de IE.
						this.req = new ActiveXObject('Microsoft.XMLHTTP');
					}
					catch(e) {
						// no se pudo crear un objeto XMLHttpRequest.
						return false;
					}
				}
			}
		}
		return this.req;
	};
	
	this.doReq = function() {
		if (!this.init()) {
			alert('no se pudo crear un objeto XMLHttpRequest.');
			return;
		}
		this.req.open(this.method, this.url, this.async);
		if (this.mimeType) {
			try {
				req.overrideMimeType(this.mimeType);
			}
			catch (e) {
				// couldn't override MIME type -- IE6 or Opera?
			}
		}
		var self = this; // Fix loss-of-scope in inner function
		this.req.onreadystatechange = function() {
			if (self.req.readyState == ecState.completed) {
				switch (self.responseFormat) {
					case 'text':
						resp = self.req.responseText;
						break;
					case 'xml':
						resp = self.req.responseXML;
						break;
					case 'object':
						resp = req;
						break;
				}
				if (self.req.status >= ecHttpStatus.OK && self.req.status <= 299) {
					(self.extraRespParam!=null)?self.handleResp(resp, self.extraRespParam):self.handleResp(resp);
				}
				else {
					self.handleErr(resp);
				}
			}
		};
		this.req.setRequestHeader('Content-Type','application/x-www-form-urlencoded');
		for(var i=0; i<this.data.length; i++) {
			this.req.setRequestHeader(this.data[i][0], this.data[i][1]);
		}
		this.req.send(this.postData);
	};
	
	this.setMethod = function(method) {
		this.method = method;
	};

	this.setRequestHeader = function(key, value) {
		this.req.setRequestHeader(key, value);
	};
	
	this.addData = function(key, value) {
		this.data[this.data.length] = new Array(key, value);
	};
	
	this.setMimeType = function(mimeType) {
		this.mimeType = mimeType;
	};
	
	this.handleErr = function() {
		var errorWin;
		try {
			errorWin = window.open('','errorWin');
			errorWin.document.body.innerHTML = this.responseText;
		}
		catch (e) {
			alert('Error:\n'
			+ 'Status Code: ' + this.req.status + '\n'
			+ 'Status Description: ' + this.req.statusText);
		}
	};

	this.setHandleResp = function(funcRef) {
		this.handleResp = funcRef;
	};

	this.setHandleErr = function(funcRef) {
		this.handleErr = funcRef;
	};

	this.setHandlerBoth = function(funcRef) {
		this.handleResp = funcRef;
		this.handleErr = funcRef;
	};

	this.abort = function() {
		if (this.req) {
			this.req.onreadystatechange = function() {};
			this.req.abort();
			this.req = null;
		}
	};

	this.doGet = function(url, hand, format, extraRespParam) {
		this.method = 'GET';
		this.url = url;
		this.handleResp = hand;
		this.responseFormat = format || 'text';
		this.extraRespParam = extraRespParam;
		this.doReq();
	};

	this.doPost = function(url, postData, hand, format, extraRespParam) {
		this.method = 'POST';
		this.url = url;
		this.postData = postData;
		this.handleResp = hand;
		this.responseFormat = format || 'text';
		this.extraRespParam = extraRespParam;
		this.doReq();
	};
}