import { Attachment } from './attachment';
import { Tag } from './tag';
import { Comment } from './comment';


export interface Post {
    id: number;
    title: string;
    slug: string;
    text: string;
    author: string;
    pubDate?: Date;
    commentOpen?: boolean;
    articleSource?: string;
    tags?: Tag[];
    comments?: Comment[];
    attachment?: Attachment[];

}
