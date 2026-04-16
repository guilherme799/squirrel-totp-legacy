class SquirrelPlayGroudApp {
    constructor() {
        this.apiBaseUrl = "https://localhost:44342/";
        this.totpUri = "";
        this.secretKey = "";
        this.qrCode = "";

        this.getTotpConfig().then((model) => {
            this.totpUri = model?.totpUri;
            this.secretKey = model?.secretKey;
            this.qrCode = `data:image/png;base64,${model?.qrCode}`;
        });
    }

    async getTotpConfig() {
        let authorization = btoa("dev@totvs.com.br:password");
        let response = await fetch(`${this.apiBaseUrl}api/totp/configuration`, {
            method: "GET",
            headers: {
                "Authorization": `Basic ${authorization}`
            }
        });

        if (response.ok)
            return response.json();

        return null;
    }
}

var $model = new SquirrelPlayGroudApp();