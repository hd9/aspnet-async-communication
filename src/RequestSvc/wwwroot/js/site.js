// simple Vue + Axios app to request data
// from endpoing
var reqApp = new Vue({
    el: '#reqApp',
    data: {
        product: null,
        slug: null,
        timeout: 1,
        loading: false,
        error: null
    },
    methods: {
        submit: function () {
            if (!this.slug) {
                alert('Please, enter a slug.')
                return;
            }

            this.error = null;
            this.loading = true;
            this.product = null;

            axios.get(`/api/products/${this.slug}?timeout=${this.timeout}`)
                .then(function (r) {
                    if (r && r.data) {
                        reqApp.product = r.data;
                    }
                    else {
                        reqApp.error = 'No data found';
                    }
                })
                .catch(function (error) {
                    reqApp.error = `Error querying the remote endpoint: ${error}`;
                })
                .then(function () {
                    reqApp.loading = false;
                });
        }
    }

});
