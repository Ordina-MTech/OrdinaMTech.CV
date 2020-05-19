import React, { Component } from 'react';
import NavMenu from './NavMenu';
import Personalia from './Personalia';
import Opleidingen from './Opleidingen';
import Cursussen from './Cursussen';
import Werkervaring from './Werkervaring';
import Kennis from './Kennis';

export class Cv extends Component {
    constructor(props) {
        super(props);
        this.state = {
            cv: null,
            isLoaded: false,
        }
    }
    componentDidMount() {       
        fetch(process.env.REACT_APP_WEBAPI_URL + "/cv")
            .then(res => res.json())
            .then((data) => {
                this.setState({
                    cv: data,
                    isLoaded: true,
                });
            })
            .catch(error => console.log(error)
            );
    }
    render() {
        const { isLoaded, cv } = this.state;
        if (isLoaded) {
            return (
                <React.Fragment>
                    <NavMenu personalia={cv.personalia} />
                    <div className="container-fluid p-0">
                        <Personalia personalia={cv.personalia} />
                        <Opleidingen opleidingen={cv.opleidingen} />
                        <Cursussen cursussen={cv.cursussen} />
                        <Werkervaring werkervaring={cv.werkervaring} />
                        <Kennis kennis={cv.kennis} />
                    </div>
                </React.Fragment>
            );
        }
        else {
            return ("Loading...");
        }
    }
}