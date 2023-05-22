import React, { Component } from 'react';
import moment from 'moment'

class Cursussen extends Component {
    render() {
        return (
            <React.Fragment>
                <section className="resume-section p-3 p-lg-5 d-flex justify-content-center" id="courses">
                    <div className="w-100">
                        <h2 className="mb-5">Cursussen</h2>
                        {this.props.cursussen.map(cursus => (
                            <div key={cursus.id} className="resume-item d-flex flex-column flex-md-row justify-content-between mb-5">
                                <div className="resume-content">
                                    <h3 className="mb-0">{cursus.naam}</h3>
                                    <div className="subheading mb-3">{cursus.instituut}</div>
                                    <div>Certificaat: {cursus.Certificaat ? "Ja" : "Nee"}</div>
                                </div>
                                <div className="resume-date text-md-right">
                                    <span className="text-primary">{moment(cursus.datum).format("MM/YYYY")}</span>
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
export default Cursussen