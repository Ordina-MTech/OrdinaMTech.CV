import React, { Component } from 'react';
import moment from 'moment';
import UploadImage from './UploadImage';

class Personalia extends Component {
    render() {
        return (
            <React.Fragment>
                <section className="resume-section p-3 p-lg-5 d-flex align-items-center" id="about">
                    <div className="w-100">
                        <UploadImage foto={this.props.personalia.foto} />
                        <h1 className="mb-0">{this.props.personalia.naam}</h1>
                        <div className="subheading mb-5">
                            Geboortedatum: {moment(this.props.personalia.geboortedatum).format("DD-MM-YYYY")}
                            <br />
                        Woonplaats: {this.props.personalia.woonplaats}
                        </div>
                        <p className="lead mb-5">Hobbies: {this.props.personalia.hobbies}</p>
                    </div>
                </section>
                <hr className="m-0" />
            </React.Fragment>
        );
    }
}
export default Personalia