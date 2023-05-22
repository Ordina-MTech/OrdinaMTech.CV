import React, { Component } from 'react';

class Kennis extends Component {
    render() {
        return (
            <React.Fragment>
                <section className="resume-section p-3 p-lg-5 d-flex justify-content-center" id="skills">
                    <div className="w-100">
                        <h2 className="mb-5">Kennis</h2>
                        {this.props.kennis.map(kennisitem => (
                            <div key={kennisitem.id} className="resume-item d-flex flex-column flex-md-row justify-content-between mb-5">
                                <div className="resume-content">
                                    <h3 className="mb-0">{kennisitem.kennisgebied}</h3>
                                    <span className={"fa fa-star " + (kennisitem.kennisniveau >= 1 ? "checked" : "")}></span>
                                    <span className={"fa fa-star " + (kennisitem.kennisniveau >= 2 ? "checked" : "")}></span>
                                    <span className={"fa fa-star " + (kennisitem.kennisniveau >= 3 ? "checked" : "")}></span>
                                    <span className={"fa fa-star " + (kennisitem.kennisniveau >= 4 ? "checked" : "")}></span>
                                    <span className={"fa fa-star " + (kennisitem.kennisniveau >= 5 ? "checked" : "")}></span>
                                </div>
                            </div>
                        ))}
                    </div>
                </section>
            </React.Fragment>
        );
    }
}
export default Kennis