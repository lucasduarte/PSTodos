export class GenericResultBase {
    public errors: string[];
    public success: boolean;
}

export class GenericResult<TResult> extends GenericResultBase {
    public result: TResult;
}