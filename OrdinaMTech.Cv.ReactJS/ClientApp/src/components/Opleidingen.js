import React, { Component } from 'react';
import moment from 'moment'

class Opleidingen extends Component {
    render() {
        return (
            <React.Fragment>
                <section className="resume-section p-3 p-lg-5 d-flex justify-content-center" id="education">
                    <div className="w-100">
                        <h2 className="mb-5">Opleiding</h2>
                        {this.props.opleidingen.map(opleiding => (
                            <div key={opleiding.id} className="resume-item d-flex flex-column flex-md-row justify-content-between mb-5">
                                <div className="resume-content">
                                    <h3 className="mb-0">{opleiding.school}</h3>
                                    <div className="subheading mb-3">{opleiding.niveau}</div>
                                    <div>Diploma: {opleiding.diploma ? "Ja" : "Nee"}</div>
                                </div>
                                <div className="resume-date text-md-right">
                                    <span className="text-primary">{moment(opleiding.datumVan).format("MM/YYYY")} - {moment(opleiding.datumTm).format("MM/YYYY")}</span>
                                </div>
                            </div>
                        ))}
                    </div>
                </section>
                <hr className="m-0" />
            </React.Fragment>
        );
    }
}
export default Opleidingen