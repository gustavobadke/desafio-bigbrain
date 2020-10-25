export default (props) => (
    <div className="col-md-4 col-sm-6 col-12 mb-2">
        <div className="card">
            <div className="card-body">
                <h5 className="card-title text-truncate" title={props.displayName}>{props.displayName}</h5>
                <h6 className="card-subtitle text-muted text-truncate" title={props.mail}>{props.mail}</h6>
            </div>
        </div>
    </div>
)