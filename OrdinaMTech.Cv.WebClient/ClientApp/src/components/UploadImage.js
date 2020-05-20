const React = require('react')

class UploadImage extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            file: 'data:image/png;base64,' + this.props.foto,
            isLoaded: true,
            error: null
        }
        this.handleChange = this.handleChange.bind(this)
        this.getBase64 = this.getBase64.bind(this)
        this.uploadFile = this.uploadFile.bind(this)
    }
    getBase64(file) {
        var that = this;
        var reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = function () {
            that.setState({
                file: reader.result,
                isLoaded: true,
                error: null,
            });
        };
        reader.onerror = function (error) {
            console.log('Error: ', error);
        };
    }
    handleChange(event) {
        this.setState({
            isLoaded: false,
            error: null,
            file: null,
        });
        this.uploadFile(event.target.files[0]);
    }
    uploadFile(file) {
        var that = this;
        var data = new FormData();
        data.append("file", file);
        fetch(process.env.REACT_APP_WEBAPI_URL + "/cv/personalia/foto/upload", {
            // content-type header should not be specified!
            method: 'POST',
            body: data
        })
            .then(response => {
                if (response.status === 202) {
                    that.getBase64(file);
                }
                else {
                    response.text()
                        .then(response => {
                            that.setState({
                                file: null,
                                isLoaded: false,
                                error: response
                            })
                        });                    
                }
            })
            .catch(error => console.log(error)
            );
    }
    render() {
        const { isLoaded, file, error } = this.state;

        if (error) {
            return (
                <div className="profile-pic float-right">
                    {error}
                    <label className="btn">
                        <span className="fas fa-edit fa-lg"></span>
                        <input type="file" className="d-none" onChange={this.handleChange} />
                    </label>
                </div>
            );
        }

        if (isLoaded) {
            return (
                <div className="profile-pic float-right">
                    <img className="img-profile rounded-circle img-fluid mr-2" src={file} alt="Foto" />
                    <label className="btn">
                        <span className="edit fas fa-edit fa-lg"></span>
                        <input type="file" className="d-none" onChange={this.handleChange} />
                    </label>
                </div>
            );
        }
        else {
            return (
                <div className="profile-pic float-right">
                    Uploading...
                </div>
            );
        }
    }
}
export default UploadImage