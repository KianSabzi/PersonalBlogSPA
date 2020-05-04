export interface Attachment {
    id: number;
    name?: string;
    type?: number;
    size?: number;
    path: string;
    isIndex: boolean;
}
