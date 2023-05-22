import React, { Component } from 'react';
import moment from 'moment';

class Werkervaring extends Component {
    render() {
        return (
            <React.Fragment>
                <section className="resume-section p-3 p-lg-5 d-flex justify-content-center" id="experience">
                    <div className="w-100">
                        <h2 className="mb-5">Werkervaring</h2>
                        {this.props.werkervaring.map(ervaring => (
                            <div key={ervaring.id} className="resume-item d-flex flex-column flex-md-row justify-content-between mb-5">
                                <div className="resume-content">
                                    <h3 className="mb-0">{ervaring.functie}</h3>
                                    <div className="subheading mb-3">{ervaring.organisatie}</div>
                                    <p>{ervaring.beschrijving}</p>
                                </div>
                                <div className="resume-date text-md-right">
                                    <span className="text-primary">{moment(ervaring.datumVan).format("MM/YYYY")} - {moment(ervaring.datumTm).isValid() ? moment(ervaring.datumTm).format("MM/YYYY") : "heden"}</span>
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
export default Werkervaring